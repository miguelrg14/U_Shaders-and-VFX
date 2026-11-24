using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

namespace VFXNotes.EditorTools
{
    /// <summary>
    /// Project setup and scene scaffolding for the VFX notes.
    /// - On load (and from the menu) makes sure URP, its renderer and a post-processing profile exist and are assigned.
    /// - "Create missing effect scenes" reads Assets/VFXNotes/effects.txt and creates, for every listed effect,
    ///   a folder (Textures, Materials, Shaders, VFX), a README and a ready-to-use scene, then refreshes the Build Settings.
    /// </summary>
    [InitializeOnLoad]
    public static class VFXNotesSetup
    {
        private const string Root = "Assets/VFXNotes";
        private const string Common = Root + "/_Common";
        private const string SettingsFolder = Common + "/Settings";
        private const string RendererPath = SettingsFolder + "/URP_Renderer.asset";
        private const string PipelinePath = SettingsFolder + "/URP_Asset.asset";
        private const string ProfilePath = SettingsFolder + "/PostProcessing_Profile.asset";
        private const string GroundMaterialPath = Common + "/Materials/M_Ground.mat";
        private const string MenuScenePath = Common + "/Scenes/00_Menu.unity";
        private const string EffectListPath = Root + "/effects.txt";

        static VFXNotesSetup()
        {
            EditorApplication.delayCall += () =>
            {
                if (SessionState.GetBool("VFXNotesSetup.Done", false)) return;
                SessionState.SetBool("VFXNotesSetup.Done", true);
                SetupPipeline();
            };
        }

        [MenuItem("Tools/VFX Notes/1. Setup URP and post-processing", false, 1)]
        public static void SetupPipeline()
        {
            EnsureFolder(SettingsFolder);

            var renderer = AssetDatabase.LoadAssetAtPath<UniversalRendererData>(RendererPath);
            if (renderer == null)
            {
                renderer = ScriptableObject.CreateInstance<UniversalRendererData>();
                AssetDatabase.CreateAsset(renderer, RendererPath);
            }

            var pipeline = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(PipelinePath);
            if (pipeline == null)
            {
                pipeline = UniversalRenderPipelineAsset.Create(renderer);
                pipeline.supportsHDR = true;
                AssetDatabase.CreateAsset(pipeline, PipelinePath);
            }

            if (GraphicsSettings.defaultRenderPipeline != pipeline)
            {
                GraphicsSettings.defaultRenderPipeline = pipeline;
            }

            var profile = AssetDatabase.LoadAssetAtPath<VolumeProfile>(ProfilePath);
            if (profile == null)
            {
                profile = ScriptableObject.CreateInstance<VolumeProfile>();
                AssetDatabase.CreateAsset(profile, ProfilePath);

                Bloom bloom = profile.Add<Bloom>(true);
                bloom.threshold.Override(0.9f);
                bloom.intensity.Override(1.5f);
                bloom.scatter.Override(0.7f);
                AssetDatabase.AddObjectToAsset(bloom, profile);

                Tonemapping tonemapping = profile.Add<Tonemapping>(true);
                tonemapping.mode.Override(TonemappingMode.ACES);
                AssetDatabase.AddObjectToAsset(tonemapping, profile);

                Vignette vignette = profile.Add<Vignette>(true);
                vignette.intensity.Override(0.25f);
                AssetDatabase.AddObjectToAsset(vignette, profile);

                EditorUtility.SetDirty(profile);
            }

            if (AssetDatabase.LoadAssetAtPath<Material>(GroundMaterialPath) == null)
            {
                EnsureFolder(Common + "/Materials");
                var shader = Shader.Find("Universal Render Pipeline/Lit");
                if (shader != null)
                {
                    var ground = new Material(shader);
                    ground.SetColor("_BaseColor", new Color(0.12f, 0.12f, 0.14f));
                    ground.SetFloat("_Smoothness", 0.2f);
                    AssetDatabase.CreateAsset(ground, GroundMaterialPath);
                }
            }

            AssetDatabase.SaveAssets();
        }

        [MenuItem("Tools/VFX Notes/2. Create missing effect scenes", false, 2)]
        public static void CreateMissingScenes()
        {
            if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
            SetupPipeline();

            if (!File.Exists(MenuScenePath)) CreateMenuScene();

            var created = 0;
            foreach (Effect effect in ReadEffectList())
            {
                string folder = Root + "/" + effect.Folder;
                string scenePath = folder + "/" + effect.Folder + ".unity";
                foreach (string sub in new[] { "Textures", "Materials", "Shaders", "VFX" }) EnsureFolder(folder + "/" + sub);
                WriteReadmeIfMissing(folder, effect);
                if (File.Exists(scenePath)) continue;
                CreateEffectScene(scenePath, effect);
                created++;
            }

            RefreshBuildSettings();
            AssetDatabase.Refresh();
            EditorSceneManager.OpenScene(MenuScenePath);
            Debug.Log("[VFX Notes] Created " + created + " effect scene(s). Build Settings updated.");
        }

        [MenuItem("Tools/VFX Notes/3. Refresh Build Settings", false, 3)]
        public static void RefreshBuildSettings()
        {
            var scenes = new List<string>();
            if (File.Exists(MenuScenePath)) scenes.Add(MenuScenePath);
            scenes.AddRange(ReadEffectList()
                .Select(e => Root + "/" + e.Folder + "/" + e.Folder + ".unity")
                .Where(File.Exists));
            EditorBuildSettings.scenes = scenes.Select(p => new EditorBuildSettingsScene(p, true)).ToArray();
        }

        // ------------------------------------------------------------------ effect list

        private struct Effect
        {
            public string Number;
            public string Folder;
            public string Title;
        }

        /// <summary>effects.txt lines: "NN | Folder-Name | Title". Lines starting with # are comments.</summary>
        private static IEnumerable<Effect> ReadEffectList()
        {
            if (!File.Exists(EffectListPath)) yield break;
            foreach (string raw in File.ReadAllLines(EffectListPath))
            {
                string line = raw.Trim();
                if (line.Length == 0 || line.StartsWith("#")) continue;
                string[] parts = line.Split('|').Select(p => p.Trim()).ToArray();
                if (parts.Length < 3) continue;
                yield return new Effect
                {
                    Number = parts[0],
                    Folder = parts[0] + "_" + parts[1],
                    Title = parts[2]
                };
            }
        }

        // ------------------------------------------------------------------ scenes

        private static void CreateMenuScene()
        {
            EnsureFolder(Common + "/Scenes");
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var camGo = new GameObject("Main Camera") { tag = "MainCamera" };
            var cam = camGo.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = new Color(0.05f, 0.05f, 0.07f);
            camGo.AddComponent<AudioListener>();

            var menu = new GameObject("_Menu").AddComponent<VFXNotes.DemoMenu>();
            menu.title = "VFX notes";
            menu.subtitle = "Real-time VFX made with Unity's VFX Graph (URP). Pick an effect; inside an effect press M to come back here.";

            EditorSceneManager.SaveScene(scene, MenuScenePath);
        }

        private static void CreateEffectScene(string scenePath, Effect effect)
        {
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Vector3 target = new Vector3(0f, 1f, 0f);

            var camGo = new GameObject("Main Camera") { tag = "MainCamera" };
            camGo.transform.position = new Vector3(0f, 1.8f, -6f);
            camGo.transform.LookAt(target);
            var cam = camGo.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = new Color(0.02f, 0.02f, 0.03f);
            cam.allowHDR = true;
            cam.GetUniversalAdditionalCameraData().renderPostProcessing = true;
            camGo.AddComponent<AudioListener>();
            camGo.AddComponent<VFXNotes.DemoOrbitCamera>().target = target;

            var lightGo = new GameObject("Directional Light");
            lightGo.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
            var light = lightGo.AddComponent<Light>();
            light.type = LightType.Directional;
            light.intensity = 0.6f;
            light.shadows = LightShadows.Soft;

            var volumeGo = new GameObject("Global Volume");
            var volume = volumeGo.AddComponent<Volume>();
            volume.isGlobal = true;
            volume.sharedProfile = AssetDatabase.LoadAssetAtPath<VolumeProfile>(ProfilePath);

            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.localScale = new Vector3(3f, 1f, 3f);
            var groundMat = AssetDatabase.LoadAssetAtPath<Material>(GroundMaterialPath);
            if (groundMat != null) ground.GetComponent<MeshRenderer>().sharedMaterial = groundMat;

            var vfxGo = new GameObject("VFX");
            vfxGo.transform.position = new Vector3(0f, 0f, 0f);
            vfxGo.AddComponent<VisualEffect>();

            var infoGo = new GameObject("_Demo Info");
            var info = infoGo.AddComponent<VFXNotes.DemoInfo>();
            info.title = effect.Number + " · " + effect.Title;
            info.description = "Notes: see README.md in this effect's folder.";
            info.controls = "R: restart · Space: pause · E: send OnPlay · F: slow motion\n" +
                            "Right mouse drag: orbit · Wheel: zoom · Middle mouse drag: pan\n" +
                            "N / B: next / previous effect · M: menu · H: hide this panel";
            infoGo.AddComponent<VFXNotes.DemoVFXControls>();

            EditorSceneManager.SaveScene(scene, scenePath);
        }

        // ------------------------------------------------------------------ helpers

        private static void WriteReadmeIfMissing(string folder, Effect effect)
        {
            string path = folder + "/README.md";
            if (File.Exists(path)) return;
            File.WriteAllText(path,
                "# " + effect.Number + " · " + effect.Title + "\n\n" +
                "- **Scene:** `" + effect.Folder + ".unity`\n" +
                "- **Graph:** `VFX/`\n\n" +
                "## Layers\n\n- \n\n" +
                "## Graph notes\n\n- **Spawn:** \n- **Initialize:** \n- **Update:** \n- **Output:** \n\n" +
                "## Textures / meshes / shaders\n\n- \n");
        }

        private static void EnsureFolder(string path)
        {
            if (AssetDatabase.IsValidFolder(path)) return;
            string parent = Path.GetDirectoryName(path).Replace('\\', '/');
            EnsureFolder(parent);
            AssetDatabase.CreateFolder(parent, Path.GetFileName(path));
        }
    }
}

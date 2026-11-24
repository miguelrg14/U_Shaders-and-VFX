using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShaderStudy
{
    /// <summary>
    /// Main menu: lists every scene in the Build Settings (except itself) as a button.
    /// </summary>
    public class DemoMenu : MonoBehaviour
    {
        public string title = "Shaders & VFX study";
        [TextArea(2, 6)] public string subtitle = "";
        public int columns = 3;

        private Vector2 scroll;
        private string[] sceneNames;

        private void Awake()
        {
            int count = SceneManager.sceneCountInBuildSettings;
            sceneNames = new string[count];
            for (int i = 0; i < count; i++)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = Path.GetFileNameWithoutExtension(path);
                sceneNames[i] = sceneName.Replace('_', ' ').Replace('-', ' ');
#if UNITY_WEBGL
                // WebGL has no geometry or tessellation shaders: these demos only work in the desktop build.
                if (sceneName.StartsWith("45_") || sceneName.StartsWith("46_") || sceneName.StartsWith("47_") || sceneName.StartsWith("48_"))
                    sceneNames[i] += "  (desktop only)";
#endif
            }
        }

        private void OnGUI()
        {
            if (sceneNames == null) return;
            float scale = Mathf.Max(1f, Screen.height / 1080f);
            GUI.matrix = Matrix4x4.Scale(new Vector3(scale, scale, 1f));
            float w = Screen.width / scale;
            float h = Screen.height / scale;

            var titleStyle = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleCenter };
            var subStyle = new GUIStyle(GUI.skin.label) { fontSize = 14, alignment = TextAnchor.MiddleCenter, wordWrap = true };
            var buttonStyle = new GUIStyle(GUI.skin.button) { fontSize = 14, alignment = TextAnchor.MiddleLeft };

            GUILayout.BeginArea(new Rect(40, 20, w - 80, h - 40));
            GUILayout.Label(title, titleStyle, GUILayout.Height(44));
            if (!string.IsNullOrEmpty(subtitle)) GUILayout.Label(subtitle, subStyle);
            GUILayout.Space(10);

            scroll = GUILayout.BeginScrollView(scroll);
            int col = 0;
            GUILayout.BeginHorizontal();
            for (int i = 1; i < sceneNames.Length; i++)
            {
                if (GUILayout.Button(sceneNames[i], buttonStyle, GUILayout.Height(34), GUILayout.Width((w - 120) / columns)))
                {
                    SceneManager.LoadScene(i);
                }
                col++;
                if (col >= columns)
                {
                    col = 0;
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }
}

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VFXNotes
{
    /// <summary>
    /// Main menu: lists every scene in the Build Settings (except itself) as a button.
    /// </summary>
    public class DemoMenu : MonoBehaviour
    {
        public string title = "VFX notes";
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
                sceneNames[i] = Path.GetFileNameWithoutExtension(path).Replace('_', ' ').Replace('-', ' ');
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

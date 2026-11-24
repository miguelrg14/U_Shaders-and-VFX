using UnityEngine;
using UnityEngine.SceneManagement;

namespace VFXNotes
{
    /// <summary>
    /// On-screen panel shown in every demo scene (Play mode): title, notes,
    /// controls and navigation between the demo scenes listed in the Build Settings.
    /// Keys: N / PageDown = next scene, B / PageUp = previous scene, M = menu, H = hide panel.
    /// </summary>
    public class DemoInfo : MonoBehaviour
    {
        public string title = "Demo";
        [TextArea(3, 12)] public string description = "";
        [TextArea(2, 8)] public string controls = "";
        public bool showPanel = true;

        private Vector2 scroll;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H)) showPanel = !showPanel;
            if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.PageDown)) LoadRelative(+1);
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.PageUp)) LoadRelative(-1);
            if (Input.GetKeyDown(KeyCode.M)) LoadMenu();
        }

        public static void LoadMenu()
        {
            if (SceneManager.sceneCountInBuildSettings > 0) SceneManager.LoadScene(0);
        }

        public static void LoadRelative(int direction)
        {
            int count = SceneManager.sceneCountInBuildSettings;
            int current = SceneManager.GetActiveScene().buildIndex;
            if (count <= 1 || current < 0) return;
            int next = current + direction;
            // Index 0 is the menu: wrap around the demo scenes only.
            if (next < 1) next = count - 1;
            if (next >= count) next = 1;
            SceneManager.LoadScene(next);
        }

        private void OnGUI()
        {
            float scale = Mathf.Max(1f, Screen.height / 1080f);
            GUI.matrix = Matrix4x4.Scale(new Vector3(scale, scale, 1f));
            float width = 430f;
            float maxHeight = Screen.height / scale - 20f;

            if (!showPanel)
            {
                if (GUI.Button(new Rect(10, 10, 150, 26), "Show info (H)")) showPanel = true;
                return;
            }

            GUILayout.BeginArea(new Rect(10, 10, width, maxHeight));
            GUILayout.BeginVertical(GUI.skin.box);

            var titleStyle = new GUIStyle(GUI.skin.label) { fontSize = 18, fontStyle = FontStyle.Bold, wordWrap = true };
            var bodyStyle = new GUIStyle(GUI.skin.label) { fontSize = 13, wordWrap = true, richText = true };

            GUILayout.Label(title, titleStyle);
            scroll = GUILayout.BeginScrollView(scroll, GUILayout.MaxHeight(maxHeight * 0.6f));
            if (!string.IsNullOrEmpty(description)) GUILayout.Label(description, bodyStyle);
            if (!string.IsNullOrEmpty(controls))
            {
                GUILayout.Space(6);
                GUILayout.Label("<b>Controls</b>\n" + controls, bodyStyle);
            }
            GUILayout.EndScrollView();

            GUILayout.Space(6);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("< Prev (B)")) LoadRelative(-1);
            if (GUILayout.Button("Menu (M)")) LoadMenu();
            if (GUILayout.Button("Next (N) >")) LoadRelative(+1);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Hide (H)")) showPanel = false;
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}

using System;
using UnityEngine;

namespace ShaderStudy
{
    /// <summary>
    /// Switches between several variants of a demo (image-effect components and/or GameObjects).
    /// Keys: Tab = next variant, 1..9 = pick a variant, 0 = disable all (when allowed).
    /// </summary>
    public class DemoVariantSwitcher : MonoBehaviour
    {
        [Serializable]
        public class Variant
        {
            public string label = "Variant";
            public Behaviour[] behaviours = new Behaviour[0];
            public GameObject[] objects = new GameObject[0];
        }

        public Variant[] variants = new Variant[0];
        public int current = 0;
        public bool allowNone = true;

        private void Start()
        {
            Apply();
        }

        private void Update()
        {
            if (variants.Length == 0) return;
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                current = (current + 1) % (variants.Length + (allowNone ? 1 : 0));
                Apply();
            }
            for (int i = 0; i < Mathf.Min(9, variants.Length); i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)) { current = i; Apply(); }
            }
            if (allowNone && Input.GetKeyDown(KeyCode.Alpha0)) { current = variants.Length; Apply(); }
        }

        public void Apply()
        {
            // Disable everything first so variants can share components/objects.
            foreach (Variant v in variants)
            {
                foreach (Behaviour b in v.behaviours) if (b != null) b.enabled = false;
                foreach (GameObject g in v.objects) if (g != null) g.SetActive(false);
            }
            if (current >= 0 && current < variants.Length)
            {
                foreach (Behaviour b in variants[current].behaviours) if (b != null) b.enabled = true;
                foreach (GameObject g in variants[current].objects) if (g != null) g.SetActive(true);
            }
        }

        private void OnGUI()
        {
            if (variants.Length == 0) return;
            float scale = Mathf.Max(1f, Screen.height / 1080f);
            GUI.matrix = Matrix4x4.Scale(new Vector3(scale, scale, 1f));
            string label = current < variants.Length ? variants[current].label : "None (effect off)";
            var style = new GUIStyle(GUI.skin.box) { fontSize = 14, alignment = TextAnchor.MiddleLeft, richText = true };
            float h = Screen.height / scale;
            GUI.Box(new Rect(10, h - 44, 520, 34), "  <b>" + label + "</b>   (Tab / 1-" + Mathf.Min(9, variants.Length) + (allowNone ? " / 0 = off" : "") + ")", style);
        }
    }
}

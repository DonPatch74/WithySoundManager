using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Withy;

namespace Withy{
    [CustomEditor(typeof (Sound))]
    public class SoundGUI : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (Sound) target;

            GUILayout.Space(20);
            GUILayout.Label("Set the Object", EditorStyles.boldLabel);

            if (!script.GetIsSaved())
            {
                if (GUILayout.Button("Save", GUILayout.Height(20)))
                {
                    script.Save();
                }
            }
            else
            {
                if (GUILayout.Button("Reset", GUILayout.Height(20)))
                {
                    script.Reset();
                }
            }
        }
    }
}
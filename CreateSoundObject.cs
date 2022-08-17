using UnityEngine;
using System.Collections;
using UnityEditor;
using Withy;

namespace Withy{
    public class CreateSoundObject {
        //[MenuItem("SoundManager/Create SoundObject")]
        public static void CreateMyAsset()
        {
            Sound asset = ScriptableObject.CreateInstance<Sound>();

            AssetDatabase.CreateAsset(asset, "Assets/SoundManagerAsset/Sounds/NewScripableObject.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}

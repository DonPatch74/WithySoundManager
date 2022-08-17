using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Withy;

namespace Withy{
    //[CreateAssetMenu(fileName = "SoundAssetsList", menuName = "Withy Sound Manager/Sounds Assets List")]
    public class SoundAssets : ScriptableObject
    {
        public static SoundAssets instance{
            get
            {
                if(_instance == null)
                {
                    _instance = FindObjectOfType<SoundAssets>();

                    if(_instance == null)
                    {
                        SoundAssets asset = CreateInstance<SoundAssets>();
                        string path = "Assets/WithySoundManager/System/SoundAssetsList.asset";
                        AssetDatabase.CreateAsset(asset, path);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        _instance = asset;
                    }
                }
                return _instance;
            }

            set => _instance = value;
        }

        private static SoundAssets _instance = null;

        [HideInInspector]
        public List<Sound> soundsList = new List<Sound>();

        private void OnEnable() {
            instance = this;
        }

        private void Awake() {
            instance = this;
        }

        public void AddToSoundsList(Sound sound) {
            clearNulls();
            soundsList.Add(sound);
        }

        public void RemoveFromSoundsList(Sound sound){
            soundsList.Remove(sound);
        }

        public void clearNulls(){
            soundsList.RemoveAll(x => x == null);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Withy;

namespace Withy{
    //[CreateAssetMenu(fileName = "SoundAssetsList", menuName = "Withy Sound Manager/Sounds Assets List")]
    public class SoundAssets : ScriptableObject
    {
        public static SoundAssets instance;
        public List<Sound> soundsList;

        private void OnEnable() {
            instance = this;
        }

        private void Awake() {
            instance = this;
        }

        public void AddToSoundsList(Sound sound) {
            soundsList.Add(sound);
        }

        public void RemoveFromSoundsList(Sound sound){
            soundsList.Remove(sound);
        }
    }
}

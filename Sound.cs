using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Withy;

namespace Withy{
    [
        CreateAssetMenu(
            fileName = "Create SoundObject",
            menuName = "Withy Sound Manager/Sound Object")
    ]
    public class Sound : ScriptableObject
    {
        [Header("Sound Name Identifier")]
        [DrawIf("isSaved", false, ComparisonType.Equals, DisablingType.ReadOnly)]
        [Tooltip("The name of the sound, once saved cannot be changed.")]
        public string soundName;

        [Header("Sound Properties")]
        [Tooltip("Select Clip that will be played.")]
        public AudioClip audioClip;

        [Tooltip("Set the volume of the sound.")]
        [Range(0.0f, 1.0f)]
        public float volume = 1.0f;

        [Tooltip("Allow to play the same sound multiple times.")]
        public bool isOverlapping;

        [Tooltip("Sound information for debugging.")]
        [Space(10)]
        [Header("Other")]
        [TextArea(3,10)]
        public string info = "";

        private bool isPlaying;

        [HideInInspector]
        public bool isSaved;

        private float lastTimePlayed;

        private void OnEnable() {
            SetIsPlaying(false);
            SetLastTimePlayed(Time.time);
        }

        public bool GetIsPlaying()
        {
            return isPlaying;
        }

        public void SetIsPlaying(bool isPlaying)
        {
            this.isPlaying = isPlaying;
        }

        public float GetLastTimePlayed()
        {
            return lastTimePlayed;
        }

        public void SetLastTimePlayed(float lastTimePlayed)
        {
            this.lastTimePlayed = lastTimePlayed;
        }

        public bool GetIsSaved()
        {
            return isSaved;
        }

        public void Save()
        {
            if (soundName == null || soundName.Count() == 0)
            {
                Debug.LogError("Sound name is null");
                return;
            }

            if (Withy.SoundTypesGenerator.checkIfSoundFileExists(soundName))
            {
                Debug.Log("Sound " + soundName);
                Debug.LogError("Sound name already exists");
                return;
            }

            if (!Withy.SoundAssets.instance)
            {
                Debug
                    .LogError("Sound Assets object missing!");
            }
            else
            {
                isSaved = true;
                Withy.SoundAssets.instance.AddToSoundsList(this);
                Withy.SoundTypesGenerator.RegenerateSoundTypes();
            }
        }

        public void Reset()
        {
            isSaved = false;

            if (!Withy.SoundAssets.instance)
            {
                Debug
                    .LogError("Sound Assets object missing!");
            }
            else
            {
                Withy.SoundAssets.instance.RemoveFromSoundsList(this);
                Withy.SoundTypesGenerator.RegenerateSoundTypes();
            }

            soundName = "";
        }
    }
}

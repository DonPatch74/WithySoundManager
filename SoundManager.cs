using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Withy;

namespace Withy{
    public static class SoundManager
    {
        private static GameObject soundParent{
            get{
                if(!_soundParent){
                    _soundParent = new GameObject("SoundParent");
                }
                return _soundParent;
            }
            set => _soundParent = value;
        }

        private static GameObject _soundParent = null;

        public static void PlaySound(SoundTypes soundType)
        {
            string sound = soundType.ToString();
            Sound soundObject = GetSoundObject(sound);

            if (soundObject == null)
            {
                Debug.Log("Sound not found: " + sound);
                return;
            }

            if (CanPlaySound(soundObject) || soundObject.isOverlapping)
            {
                soundObject.SetIsPlaying(true);
                GameObject soundGameObject = new GameObject("Sound" + sound);
                soundGameObject.transform.parent = soundParent.transform;
                AudioSource audioSource =
                soundGameObject.AddComponent<AudioSource>();
                audioSource.clip = soundObject.audioClip;
                audioSource.volume = soundObject.volume;

                audioSource.Play();

                soundObject.SetLastTimePlayed(Time.time);
                Object.Destroy(soundGameObject, soundObject.audioClip.length);
            }
        }

        public static void PlaySound(string sound, Vector3 position)
        {
            Sound soundObject = GetSoundObject(sound);

            if (soundObject == null)
            {
                Debug.Log("Sound not found: " + sound);
                return;
            }

            if (CanPlaySound(soundObject) || soundObject.isOverlapping)
            {
                soundObject.SetIsPlaying(true);
                GameObject soundGameObject = new GameObject("Sound" + sound);
                soundGameObject.transform.parent = soundParent.transform;
                AudioSource audioSource =
                soundGameObject.AddComponent<AudioSource>();
                audioSource.clip = soundObject.audioClip;
                audioSource.volume = soundObject.volume;

                soundGameObject.transform.position = position;
                audioSource.maxDistance = 100f;
                audioSource.spatialBlend = 1f;
                audioSource.rolloffMode = AudioRolloffMode.Linear;
                audioSource.dopplerLevel = 0f;

                audioSource.Play();

                soundObject.SetLastTimePlayed(Time.time);
                Object.Destroy(soundGameObject, soundObject.audioClip.length);
            }
        }

        public static Sound GetSoundObject(string soundNameFrom)
        {
            if (!SoundAssets.instance)
            {
                Debug.Log("SoundAssets not found");
                return null;
            }

            foreach (Sound soundAudioClip in SoundAssets.instance.soundsList)
            {
                if (soundAudioClip.soundName == soundNameFrom)
                {
                    return soundAudioClip;
                }
            }

            Debug
                .LogError("GetSoundObject: Error: Sound Not Found " +
                soundNameFrom);
            return null;
        }

        private static bool CanPlaySound(Sound sound)
        {
            bool canPlay = sound.GetIsPlaying();

            if (!canPlay)
            {
                return true;
            }

            if (WaitUntilSoundFinish(sound))
            {
                return true;
            }

            return false;
        }

        private static bool WaitUntilSoundFinish(Sound sound)
        {
            if (sound.GetLastTimePlayed() + sound.audioClip.length < Time.time)
            {
                sound.SetIsPlaying(false);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static float GetObjectVolume(SoundTypes soundType)
        {
            string sound = soundType.ToString();
            Sound soundObject = GetSoundObject(sound);

            if (soundObject == null)
            {
                Debug.Log("Sound not found: " + sound);
                return 0;
            }

            return soundObject.volume;
        }

        public static void SetObjectVolume(SoundTypes soundType, float volume)
        {
            string sound = soundType.ToString();
            Sound soundObject = GetSoundObject(sound);

            if (soundObject == null)
            {
                Debug.Log("Sound not found: " + sound);
                return;
            }
            soundObject.volume = volume;
        }
    }
}
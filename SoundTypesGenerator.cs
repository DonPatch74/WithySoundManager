#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Withy;

namespace Withy{
    public class SoundTypesGenerator
    {
        private static string enumName = "SoundTypes";

        private static string
            filePathAndName =
                "Assets/WithySoundManager/System/WithySoundTypes/" + enumName + ".cs"; //The folder Scripts/Enums/ is expected to exist

        //[MenuItem("SoundManager/Optimise")]
        public static void RegenerateSoundTypes()
        {
            CreateEnumFile(GetAllEnumEntries());
        }

        private static List<string> GetAllEnumEntries()
        {
            List<string> enumEntries = new List<string>();

            var allSounds = AssetDatabase.FindAssets("t: Sound");

            foreach (var guid in allSounds)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var soundObject = AssetDatabase.LoadAssetAtPath<Sound>(path);

                if (soundObject != null)
                {
                    if (
                        soundObject.soundName != "" &&
                        soundObject.soundName.Count() > 0 &&
                        soundObject.isSaved
                    ) enumEntries.Add(soundObject.soundName);
                }
            }
            return enumEntries;
        }

        private static List<Sound> GetAllSoundObjects()
        {
            List<Sound> soundObjects = new List<Sound>();

            var allSounds = AssetDatabase.FindAssets("t: Sound");

            foreach (var guid in allSounds)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var soundObject = AssetDatabase.LoadAssetAtPath<Sound>(path);

                if (soundObject != null)
                {
                    soundObjects.Add (soundObject);
                }
                if (soundObject != null)
                {
                    if (
                        soundObject.soundName != "" &&
                        soundObject.soundName.Count() > 0 &&
                        soundObject.isSaved
                    ) soundObjects.Add(soundObject);
                }
            }
            return soundObjects;
        }

        private static void CreateEnumFile(List<string> enumEntries)
        {
            if (File.Exists(filePathAndName))
            {
                File.Delete (filePathAndName);
            }

            using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
            {
                streamWriter.WriteLine("public enum " + enumName);
                streamWriter.WriteLine("{");
                for (int i = 0; i < enumEntries.Count; i++)
                {
                    streamWriter.WriteLine("\t" + enumEntries[i] + ",");
                }
                streamWriter.WriteLine("}");
            }
            AssetDatabase.Refresh();
        }

        public static bool checkIfSoundFileExists(string soundName)
        {
            List<Sound> soundObjects = new List<Sound>();
            soundObjects = GetAllSoundObjects();

            bool boolReturn = false;

            foreach (var sound in soundObjects){
                if (sound.soundName == soundName && sound.isSaved == true) boolReturn = true;
            }

            return boolReturn;
        }
    }
}
#endif

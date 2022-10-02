using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    [CreateAssetMenu(fileName = "New Music", menuName = "UnidosJam/Create New Music")]
    public class MusicScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct MusicSettings
        {
            public AudioClip musicClip;
            [Multiline] public string copyrightText;
        }

        public MusicSettings musicSettings;
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    [CreateAssetMenu(fileName = "New Assistant Message", menuName = "UnidosJam/Create New Assistant Message")]
    public class AssistantMessageScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct AssistantMessageOptions
        {
            [Multiline] public string[] assistantDialogues;
            public float textSpeed;
            public int gameDay;
        }
        public AssistantMessageOptions assistantMessageOptions;
    }
}
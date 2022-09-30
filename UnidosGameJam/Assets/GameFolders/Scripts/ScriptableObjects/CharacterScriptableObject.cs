using UnityEngine;

namespace UnidosJam.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Character", menuName = "UnidosJam/Create New Character")]
    public class CharacterScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct CharacterStruct
        {
            public string CharacterName;
            public PlayerDecision PlayerDecisions;
        }
        
        [System.Serializable]
        public struct PlayerDecision
        {
            public int positiveAnswers;
            public int negativeAnswers;
        }
        
        public CharacterStruct characterSettings;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Character", menuName = "UnidosJam/Create New Character")]
    public class CharacterScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct CharacterStruct
        {
            public string characterName;
            
            public PlayerDecision playerDecisions;
            public List<MailInformationScriptableObject> characterMails; // new added
            public bool isNotrCharacter;
        }
        
        [System.Serializable]
        public struct PlayerDecision
        {
            public int positiveAnswers;
            public int negativeAnswers;
            
            [Multiline(25)] public string characterPositiveEnding;
            [Multiline(25)] public string characterNegativeEnding;
        }
        
        public CharacterStruct characterSettings;
    }
}
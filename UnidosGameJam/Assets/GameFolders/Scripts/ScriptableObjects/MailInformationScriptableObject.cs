using UnityEngine;

namespace UnidosJam.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Mail Information", menuName = "UnidosJam/Create New Mail Information")]
    public class MailInformationScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct MailInformationStruct
        {
            public CharacterScriptableObject character;
            public string mailTitle;
            public string mailDate;
            [Multiline] public string MailText;
        }
        public MailInformationStruct mailInformationStruct;
    }
}
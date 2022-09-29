using UnityEngine;

namespace UnidosJam
{
    
    [CreateAssetMenu(fileName = "New Mail Information", menuName = "UnidosJam/Create New Mail Information")]
    public class MailInformationScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct MailInformationStruct
        {
            public string SenderName;
            [Multiline]
            public string MailText;
        }

        public MailInformationStruct mailInformationStruct;
    }
}
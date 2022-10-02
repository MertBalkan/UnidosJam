using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    [CreateAssetMenu(fileName = "New Monolog", menuName = "UnidosJam/Create New Monolog")]
    public class MonologScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct MonologData
        {
            [Multiline] public List<string> monologTexts;
        }

        public MonologData monologData;
    }
}
using UnityEngine;

namespace UnidosJam.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Button Settings", menuName = "UnidosJam/Create New Button UI")]
    public class ButtonScriptableObject : ScriptableObject
    {
        [System.Serializable]
        public struct SpriteSettings
        {
            public Sprite closeSprite;
            public Sprite openSprite;
        }

        public SpriteSettings spriteSettings;
    }
}
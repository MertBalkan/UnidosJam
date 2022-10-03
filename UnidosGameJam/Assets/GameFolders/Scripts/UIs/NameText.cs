using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class NameText : MonoBehaviour
    {
        private TextMeshProUGUI _nameText;

        public TextMeshProUGUI NameString => _nameText;

        private void Awake()
        {
            _nameText = GetComponent<TextMeshProUGUI>();
        }
    }
}
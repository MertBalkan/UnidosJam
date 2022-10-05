using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class NameText : MonoBehaviour
    {
        private TextMeshProUGUI _nameText;

        public TextMeshProUGUI NameString => GetComponent<TextMeshProUGUI>();

        private void Awake()
        {
            // _nameText = GetComponent<TextMeshProUGUI>();
        }
    }
}
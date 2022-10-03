using System;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class DateText : MonoBehaviour
    {
        private TextMeshProUGUI _dateText;

        public TextMeshProUGUI DateString => _dateText;

        private void Awake()
        {
            _dateText = GetComponent<TextMeshProUGUI>();
        }
    }
}
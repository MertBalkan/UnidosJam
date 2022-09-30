using System;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class MailTextPlace : MonoBehaviour
    {
        private TextMeshProUGUI _textPlace;

        public TextMeshProUGUI TextPlace
        {
            get => _textPlace;
            set => _textPlace = value;
        }

        private void Awake()
        {
            _textPlace = GetComponent<TextMeshProUGUI>();
        }

    }
}
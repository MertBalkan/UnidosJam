using System;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class GeneralTextPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fromText;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI dateText;
        
        public TextMeshProUGUI FromText => fromText;
        public TextMeshProUGUI TitleText => titleText;
        public TextMeshProUGUI DateText => dateText;
    }
}
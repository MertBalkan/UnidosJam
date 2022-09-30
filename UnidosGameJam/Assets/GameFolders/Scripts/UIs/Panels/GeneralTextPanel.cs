using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class GeneralTextPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fromText;
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI dateText;
        [SerializeField] private MailPanel currentMailPanel;

        public TextMeshProUGUI FromText => fromText;
        public TextMeshProUGUI TitleText => titleText;
        public TextMeshProUGUI DateText => dateText;

        public MailPanel CurrentMailPanel
        {
            get => currentMailPanel;
            set => currentMailPanel = value;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
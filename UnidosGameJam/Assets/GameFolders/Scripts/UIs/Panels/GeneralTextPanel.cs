using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class GeneralTextPanel : MonoBehaviour
    {
        [SerializeField] private MailPanel currentMailPanel;

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
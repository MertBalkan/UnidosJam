using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class GeneralTextPanel : MonoBehaviour
    {
        [SerializeField] private FirstDayMailPanel currentMailPanel;

        public FirstDayMailPanel CurrentMailPanel
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
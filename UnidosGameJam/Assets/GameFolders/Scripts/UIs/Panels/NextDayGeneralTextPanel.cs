using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class NextDayGeneralTextPanel : MonoBehaviour
    {
        [SerializeField] private NextDaysMailPanel currentMailPanel;

        public NextDaysMailPanel CurrentMailPanel
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
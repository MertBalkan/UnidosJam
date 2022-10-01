using System;
using UnityEngine;

namespace UnidosJam
{
    public class DecisionButton : MonoBehaviour
    {
        [SerializeField] private bool decisionButtonPressed;
        
        public bool DecisionButtonPressed
        {
            get => decisionButtonPressed;
            set => decisionButtonPressed = value;
        }

        public void PressedDecisionButton()
        {
            decisionButtonPressed = true;
        }

        private void Start()
        {
            gameObject.SetActive(true);
        }
    }
}
using System;
using UnityEngine;

namespace UnidosJam
{
    public class MailAnswersButton : MonoBehaviour
    {
        private DecisionButton[] _decisionButtons;

        public DecisionButton[] DecisionButtons => _decisionButtons;

        private void Awake()
        {
            _decisionButtons = GetComponentsInChildren<DecisionButton>();
        }

        private void Start()
        {
            gameObject.SetActive(true);
        }
    }
}
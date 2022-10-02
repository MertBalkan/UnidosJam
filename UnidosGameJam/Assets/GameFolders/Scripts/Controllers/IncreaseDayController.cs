using System;
using UnityEngine;

namespace UnidosJam
{
    public class IncreaseDayController : MonoBehaviour
    {
        public DecisionButton[] decisionButtons;
        public NextDaysMailPanel[] nextDaysMailPanels;

        private void Awake()
        {
            decisionButtons = FindObjectsOfType<DecisionButton>();
            nextDaysMailPanels = FindObjectsOfType<NextDaysMailPanel>();
            DecisionManager.Instance.DecisionCount = 0;
     
            GameManager.Instance.AssignCharactersToMails(nextDaysMailPanels);
        }

        private void Start()
        {
            IncreaseDay();
        }

        private void Update()
        {
            if (GameManager.Instance.CurrentDayCount >= 4)
            {
                // Today is last day of the game
            }
        }

        private void IncreaseDay()
        {
            GameManager.Instance.CurrentDayCount++;
        }
    }
}
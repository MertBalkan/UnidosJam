using System;
using UnityEngine;

namespace UnidosJam
{
    public class IncreaseDayController : MonoBehaviour
    {
        public NextDaysMailPanel[] nextDaysMailPanels;

        private void Awake()
        {
            nextDaysMailPanels = FindObjectsOfType<NextDaysMailPanel>();
     
            GameManager.Instance.AssignCharactersToMails(nextDaysMailPanels);
        }

        private void Start()
        {
            PositiveNegativeManager.Instance.DecisionCount = 0;
            PositiveNegativeManager.Instance.CanGoNextDay = false;
            DecisionManager.Instance.DecisionCount = 0;
            DecisionManager.Instance.CanGoNextDay = false;
            
            IncreaseDay();
        }

        public void YesButtonPressed()
        {
            PositiveNegativeManager.Instance.PlayerClickYesButton();
        }
        
        
        public void NoButtonPressed()
        {
            PositiveNegativeManager.Instance.PlayerClickNoButton();
        }

        private void IncreaseDay()
        {
            GameManager.Instance.CurrentDayCount++;
        }
    }
}
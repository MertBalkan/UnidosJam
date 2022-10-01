using System;
using System.Collections;
using System.Collections.Generic;
using UnidosJam;
using UnityEngine;

public class IncreaseDayController : MonoBehaviour
{
    public DecisionButton[] decisionButtons;
    public NextDaysMailPanel[] nextDaysMailPanels;

    private void Awake()
    {
        decisionButtons = FindObjectsOfType<DecisionButton>();
        nextDaysMailPanels = FindObjectsOfType<NextDaysMailPanel>();
     
        GameManager.Instance.AssignCharactersToMails(nextDaysMailPanels);
    }

    private void Start()
    {
        IncreaseDay();
        DecisionManager.Instance.Buttons = decisionButtons;
    }

    private void IncreaseDay()
    {
        GameManager.Instance.CurrentDayCount++;
    }
}

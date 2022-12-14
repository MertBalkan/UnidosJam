using System;
using System.Collections;
using System.Collections.Generic;
using UnidosJam;
using UnidosJam.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class PositiveNegativeManager : MonoBehaviour
{        
    [SerializeField] private Sprite readMailSprite;
    private NextDayGeneralTextPanel _generalTextPanel;
    public static PositiveNegativeManager Instance { get; private set; }
    
    private int _decisionCount = 0;
    private bool _canGoNextDay = false;
    
    public int DecisionCount
    {
        get => _decisionCount;
        set => _decisionCount = value;
    }

    public bool CanGoNextDay
    {
        get => _canGoNextDay;
        set => _canGoNextDay = value;
    }
    
    private void Awake()
    {
        SingletonObject(); 
        _generalTextPanel = FindObjectOfType<NextDayGeneralTextPanel>();

    }

    private void SingletonObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (_decisionCount >= 2)
        {
            _canGoNextDay = true;
        }
    }

    public void PlayerClickYesButton()
    {
        _decisionCount++;
        _generalTextPanel = FindObjectOfType<NextDayGeneralTextPanel>();

        _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
            .playerDecisions.positiveAnswers++;

        _generalTextPanel.CurrentMailPanel.SetAnswer("From: " + NameManager.PlayerName + "\n\n" + _generalTextPanel.CurrentMailPanel.MailInformationSo
            .playerAnswersToThisMail.PositiveAnswerToThisMail + "\n" + NameManager.PlayerName
        );
    }
    
    public void PlayerClickNoButton()
    { 
        _decisionCount++;
        _generalTextPanel = FindObjectOfType<NextDayGeneralTextPanel>();
            
        _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
            .playerDecisions.negativeAnswers++;
            
            
        _generalTextPanel.CurrentMailPanel.SetAnswer("From: " + NameManager.PlayerName + "\n\n" + _generalTextPanel.CurrentMailPanel.MailInformationSo
            .playerAnswersToThisMail.NegativeAnswerToThisMail+ "\n" + NameManager.PlayerName
        );
    }
    
    public void ReadMail()
    {
        _generalTextPanel = FindObjectOfType<NextDayGeneralTextPanel>();
        _generalTextPanel.CurrentMailPanel.GetComponent<Image>().sprite = readMailSprite;
    }
}

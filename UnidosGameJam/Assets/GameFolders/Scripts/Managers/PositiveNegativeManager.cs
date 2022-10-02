using System.Collections;
using System.Collections.Generic;
using UnidosJam;
using UnityEngine;
using UnityEngine.UI;

public class PositiveNegativeManager : MonoBehaviour
{        
    [SerializeField] private Sprite readMailSprite;
    private NextDayGeneralTextPanel _generalTextPanel;
    public static PositiveNegativeManager Instance { get; private set; }

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
    
    public void PlayerClickYesButton()
    {
        _generalTextPanel = FindObjectOfType<NextDayGeneralTextPanel>();

        _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
            .playerDecisions.positiveAnswers++;

        _generalTextPanel.CurrentMailPanel.SetAnswer("From: " + NameManager.PlayerName + "  " + _generalTextPanel.CurrentMailPanel.MailInformationSo
            .playerAnswersToThisMail.PositiveAnswerToThisMail
        );
    }
    
    public void PlayerClickNoButton()
    { 
        _generalTextPanel = FindObjectOfType<NextDayGeneralTextPanel>();
            
        _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
            .playerDecisions.negativeAnswers++;
            
            
        _generalTextPanel.CurrentMailPanel.SetAnswer("From: " + NameManager.PlayerName + "  " + _generalTextPanel.CurrentMailPanel.MailInformationSo
            .playerAnswersToThisMail.NegativeAnswerToThisMail
        );
    }
    
    
    public void ReadMail()
    {
        _generalTextPanel.CurrentMailPanel.GetComponent<Image>().sprite = readMailSprite;
    }
}

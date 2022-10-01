using System;
using TMPro;
using UnidosJam.ScriptableObjects;
using UnityEngine;

namespace UnidosJam
{
    public class NextDaysMailPanel : MonoBehaviour
    {
        [SerializeField] private AnswerText answerText;
        [SerializeField] private AnswerText[] otherAnswerTexts;
        
        [SerializeField] private MailAnswersButton mailAnswerButton;
        [SerializeField] private MailAnswersButton[] otherMailAnswers;
        
        [SerializeField] private MailInformationScriptableObject mailInformationSo;
        [SerializeField] private bool thisMailHasBeenRead;
        
        [SerializeField] private GameObject testText;
        
        private string _beforeText;
        private GeneralTextPanel _generalTextPanel;
        private MailPanels _mailPanels;

        public MailInformationScriptableObject MailInformationSo => mailInformationSo;
        public MailAnswersButton MailAnswersButton => mailAnswerButton;
        public MailAnswersButton[] OtherMailAnswers => otherMailAnswers;
        
        public string BeforeText
        {
            get => _beforeText;
            set => _beforeText = value;
        }

        public bool ThisMailHasBeenRead
        {
            get => thisMailHasBeenRead;
            set => thisMailHasBeenRead = value;
        }
        
        private void Awake()
        {
            _mailPanels = FindObjectOfType<MailPanels>();
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
        }

        private void Start()
        {
            thisMailHasBeenRead = false;
            answerText.gameObject.SetActive(false);
        }

        public void PressedPanel()
        {
            thisMailHasBeenRead = true;
            
            _generalTextPanel.CurrentMailPanel = this.gameObject.GetComponent<FirstDayMailPanel>();

            _mailPanels.gameObject.SetActive(false); 
            _generalTextPanel.gameObject.SetActive(true);

            foreach (var other in otherMailAnswers)
            {
                if(other != null)
                    other.gameObject.SetActive(false);
            }

            foreach (var other in otherAnswerTexts)
            {
                other.gameObject.SetActive(false);
            }

            if ((mailAnswerButton.DecisionButtons[0].DecisionButtonPressed ||
                mailAnswerButton.DecisionButtons[1].DecisionButtonPressed) && thisMailHasBeenRead)
            {
                if(mailAnswerButton != null)
                    mailAnswerButton.gameObject.SetActive(false);
                answerText.gameObject.SetActive(true);
            }
            else
            {
                if (!DecisionManager.Instance.CharactersSelected)
                {
                    if(mailAnswerButton != null)
                        mailAnswerButton.gameObject.SetActive(true);
                    answerText.gameObject.SetActive(true);
                }
            }
            
            CurrentDetails();
        }

        public void CurrentDetails()
        {
            var mailStruct = mailInformationSo.mailInformationStruct;
            _beforeText = "\t" + mailStruct.character.characterSettings.CharacterName + "\t" +
                          mailStruct.mailTitle + "\t" +
                          mailStruct.mailDate + "\n" + "\n" +
                          "  " + mailInformationSo.mailInformationStruct.MailText + "\n";
            
            testText.GetComponent<TextMeshProUGUI>().text = _beforeText;
        }

        public void SetAnswer(string answer)
        {
            answerText.GetComponent<TextMeshProUGUI>().text = answer;
        }
    }
}
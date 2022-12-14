using System;
using System.Linq;
using TMPro;
using UnidosJam.ScriptableObjects;
using UnityEngine;

namespace UnidosJam
{
    public class FirstDayMailPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI dateText;
            
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

        private void OnEnable()
        {
            var mailStruct = mailInformationSo.mailInformationStruct;
            
            nameText.text = mailStruct.character.characterSettings.characterName;
            dateText.text = mailStruct.mailDate;
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

            if ((mailAnswerButton.DecisionButtons[0].DecisionButtonPressed) && thisMailHasBeenRead)
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
            _beforeText = "\n" + "From: " + mailStruct.character.characterSettings.characterName + "\t" +
                          mailStruct.mailTitle + "\t" +
                         "\n" + "\n" +
                          "" + mailInformationSo.mailInformationStruct.MailText;
            
            testText.GetComponent<TextMeshProUGUI>().text = _beforeText;
        }

        public void SetAnswer(string answer)
        {
            answerText.GetComponent<TextMeshProUGUI>().text = answer;
        }
    }
}
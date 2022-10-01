using System;
using TMPro;
using UnidosJam.ScriptableObjects;
using UnityEngine;

namespace UnidosJam
{
    public class MailPanel : MonoBehaviour
    {
        public GameObject answerText;

        [SerializeField] private MailAnswersButton mailAnswerButton;
        [SerializeField] private MailAnswersButton[] otherMailAnswers;
        
        [SerializeField] private MailInformationScriptableObject mailInformationSo;
        [SerializeField] private bool thisMailHasBeenRead;
        
        [SerializeField] private GameObject testText;
        
        private string _beforeText;
        private GeneralTextPanel _generalTextPanel;
        private MailPanels _mailPanels;

        public MailInformationScriptableObject MailInformationSo => mailInformationSo;

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
        }

        public void PressedPanel()
        {
            thisMailHasBeenRead = true;
            
            _generalTextPanel.CurrentMailPanel = this.gameObject.GetComponent<MailPanel>();

            _mailPanels.gameObject.SetActive(false); 
            _generalTextPanel.gameObject.SetActive(true);

            foreach (var other in otherMailAnswers)
            {
                other.gameObject.SetActive(false);
            }

            if ((mailAnswerButton.DecisionButtons[0].DecisionButtonPressed ||
                mailAnswerButton.DecisionButtons[1].DecisionButtonPressed) && thisMailHasBeenRead)
            {
                Debug.Log("GİRDİM");
                mailAnswerButton.gameObject.SetActive(false);
            }
            else
            {
                mailAnswerButton.gameObject.SetActive(true);
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
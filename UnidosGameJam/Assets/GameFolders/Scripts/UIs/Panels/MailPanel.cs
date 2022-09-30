using System;
using UnidosJam.ScriptableObjects;
using UnityEngine;

namespace UnidosJam
{
    public class MailPanel : MonoBehaviour
    {
        [SerializeField] private MailInformationScriptableObject mailInformationSo;
        private GeneralTextPanel _generalTextPanel;
        private MailTextPlace _mailTextPlace;

        private MailPanels _mailPanels;
        public MailInformationScriptableObject MailInformationSo => mailInformationSo;
        
        private void Awake()
        {
            _mailPanels = FindObjectOfType<MailPanels>();
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
            _mailTextPlace = FindObjectOfType<MailTextPlace>();
        }

        public void PressedPanel()
        {
            _mailPanels.gameObject.SetActive(false); 
            _generalTextPanel.gameObject.SetActive(true);
            
            CurrentDetails();
        }

        public void CurrentDetails()
        {
            _mailTextPlace.TextPlace.text = mailInformationSo.mailInformationStruct.MailText;

            _generalTextPanel.FromText.text = mailInformationSo.mailInformationStruct.character.characterSettings.CharacterName;
            _generalTextPanel.TitleText.text = mailInformationSo.mailInformationStruct.mailTitle;
            _generalTextPanel.DateText.text = mailInformationSo.mailInformationStruct.mailDate;

            _generalTextPanel.CurrentMailPanel = this.gameObject.GetComponent<MailPanel>();
        }
    }
}
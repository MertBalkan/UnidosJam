using System;
using UnidosJam.ScriptableObjects;
using UnityEngine;

namespace UnidosJam
{
    public class MailPanel : MonoBehaviour
    {
        [SerializeField] private MailInformationScriptableObject mailInformationSo;
        [SerializeField] private GeneralTextPanel generalTextPanel;
        [SerializeField] private MailTextPlace mailTextPlace;

        private MailPanels _mailPanels;
        
        private void Awake()
        {
            _mailPanels = FindObjectOfType<MailPanels>();
        }

        public void PressedPanel()
        {
            _mailPanels.gameObject.SetActive(false); 
            generalTextPanel.gameObject.SetActive(true);
            mailTextPlace.TextPlace.text = mailInformationSo.mailInformationStruct.MailText;

            generalTextPanel.FromText.text = mailInformationSo.mailInformationStruct.character.characterSettings.CharacterName;
            generalTextPanel.TitleText.text = mailInformationSo.mailInformationStruct.mailTitle;
            generalTextPanel.DateText.text = "Date: " + mailInformationSo.mailInformationStruct.mailDate;

        }
    }
}
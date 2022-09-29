using System;
using UnityEngine;

namespace UnidosJam
{
    public class MailPanel : MonoBehaviour
    {
        [SerializeField] private MailInformationScriptableObject mailInformationSo;

        private MailTextPlace _mailTextPlace;
        private MailPanels _mailPanels;

        private void Awake()
        {
            _mailTextPlace = FindObjectOfType<MailTextPlace>();
            _mailPanels = FindObjectOfType<MailPanels>();
        }

        public void PressedPanel()
        {
            _mailPanels.gameObject.SetActive(false); 
            _mailTextPlace.TextPlace.text = mailInformationSo.mailInformationStruct.MailText;
        }
    }
}
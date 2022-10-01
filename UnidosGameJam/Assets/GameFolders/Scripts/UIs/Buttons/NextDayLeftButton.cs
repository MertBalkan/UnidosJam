using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class NextDayLeftButton : MonoBehaviour
    {
        [SerializeField] private NextDayGeneralTextPanel generalTextPanel;
        [SerializeField] private MailPanels mailPanels;
        [SerializeField] private MailAnswersButton[] mailAnswers;


        public void LeftButtonPressed()
        {
            foreach (var mailAnswersButton in mailAnswers)
            {
                if(mailAnswersButton != null)
                    mailAnswersButton.gameObject.SetActive(false);
            }
            mailPanels.gameObject.SetActive(true);
            generalTextPanel.gameObject.SetActive(false);
        }
    }
   
}
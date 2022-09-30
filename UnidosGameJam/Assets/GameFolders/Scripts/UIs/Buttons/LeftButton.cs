using System;
using UnityEngine;

namespace UnidosJam
{
    public class LeftButton : MonoBehaviour
    {
        [SerializeField] private GeneralTextPanel generalTextPanel;
        [SerializeField] private MailPanels mailPanels;

        public void LeftButtonPressed()
        {
            Debug.Log("CLICKED!");
            mailPanels.gameObject.SetActive(true);
            generalTextPanel.gameObject.SetActive(false);
        }
    }
}
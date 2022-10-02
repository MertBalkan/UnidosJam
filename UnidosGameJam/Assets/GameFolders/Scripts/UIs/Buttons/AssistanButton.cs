using System.Collections;
using System.Collections.Generic;
using UnidosJam.UIs;
using UnityEngine;

namespace UnidosJam
{
    public class AssistanButton : BaseButtonUI
    {
        public override void OpenNewWindow(GameObject windowPanel)
        {
            base.OpenNewWindow(windowPanel);
            
            // windowPanel.GetComponent<AssistantPanel>().StartDialogue();
        }
    }
}
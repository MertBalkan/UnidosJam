using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class CharacterMonolog : MonoBehaviour
    {
        [SerializeField] private GameObject monologueBox;
        [SerializeField] private DialogueController dialogue;
        [SerializeField] private MonologScriptableObject[] monologScriptableObjects;
    
        private void Start()
        {
            StartCoroutine(FirstDayEnumerator());
        }

        private IEnumerator FirstDayEnumerator()
        {
            yield return new WaitForSeconds(0.5f);
            FirstDayMonologue();
            yield return new WaitForSeconds(4);
            monologueBox.gameObject.SetActive(false);
        }

        public void FirstDayMonologue()
        {
            dialogue.StartDialogue(monologScriptableObjects[0].monologData.monologTexts.ToArray());
        }

        private IEnumerator NothingToDoMonologueAsync()
        {
            NothingToDoMonologue();
            yield return new WaitForSeconds(4.0f);
            monologueBox.gameObject.SetActive(false);
        }
        
        public void NothingToDoMonologue()
        {
            dialogue.StartDialogue(monologScriptableObjects[1].monologData.monologTexts.ToArray());
        }
        
        
        public void ShouldReplyMonologue()
        {
            dialogue.StartDialogue(monologScriptableObjects[2].monologData.monologTexts.ToArray());
        }
    }   
}
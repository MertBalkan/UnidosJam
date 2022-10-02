using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class CharacterMonolog : MonoBehaviour
    {
        [SerializeField] private DialogueController dialogue;
        [SerializeField] private MonologScriptableObject monologScriptableObject;
    
        private void Start()
        {
            // dialogue.StartDialogue(text);

            // FirstDayMessage();
            StartCoroutine(enen());
        }

        private void Update()
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     FirstDayMessage();
            // }
        }

        private IEnumerator enen()
        {
            yield return new WaitForSeconds(0.5f);
            FirstDayMessage();
            yield return new WaitForSeconds(8);
            dialogue.gameObject.SetActive(false);
        }

        public void FirstDayMessage()
        {
            dialogue.StartDialogue(monologScriptableObject.monologData.monologTexts.ToArray());
        }
    }   
}
using System;
using System.Collections;
using Mono.CompilerServices.SymbolWriter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float textSpeed;

        private int _index;
        private string[] _textLines;

        public TextMeshProUGUI Text => text;

        private void Start()
        {
            text.text = string.Empty;
        }

        public void StartDialogue(string[] textLines)
        {
            _index = 0;
            _textLines = textLines;
            
            StartCoroutine(TypeLine());
        }

        public void ShowNextDialogue()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (text.text == _textLines[_index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    text.text = _textLines[_index];
                }
            }
        }

        private IEnumerator TypeLine()
        {
            foreach (char c in _textLines[_index].ToCharArray())
            {
                text.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        private void NextLine()
        {
            if (_index < _textLines.Length - 1)
            {
                _index++;
                text.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                EndDialogue();
            }
        }

        private void EndDialogue()
        {
            if(!gameObject.activeInHierarchy && Input.GetMouseButtonDown(0)) return;
            
            GetComponentInParent<Image>().gameObject.SetActive(false);
        }
    }
}
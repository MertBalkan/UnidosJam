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
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float textSpeed;

        private int _index;
        private string[] _textLines;

        public TextMeshProUGUI Text => text;

        public int MonologueIndex
        {
            get => _index;
            set => _index = value;
        }

        private void Start()
        {
            text.text = string.Empty;
            characterName.text = NameManager.PlayerName;
        }

        public void StartDialogue(string[] textLines)
        {
            _index = 0;
            _textLines = textLines;
            text.text = _textLines[_index];
            
            // StartCoroutine(TypeLine());
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
            text.text = _textLines[_index];
            yield break;
            
            // foreach (char c in _textLines[_index].ToCharArray())
            // {
            //     // text.text += c;
            //     yield return new WaitForSeconds(textSpeed);
            // }
            // yield return new WaitForSeconds(textSpeed);
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
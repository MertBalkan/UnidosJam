using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class AssistantPanel : MonoBehaviour
    {
        [SerializeField] private AssistantMessageScriptableObject todaysAssistantMessage;
        [SerializeField] private TextMeshProUGUI mainAssistantText;
        [SerializeField] private GameObject[] myCloseButtons;
        
        [SerializeField] private GameObject playerTyping;
        [SerializeField] private GameObject assistantTyping;
        
        private int _index;
        private string[] _currentTextLines;

        private bool _endDialogue = false;

        private void OnEnable()
        {
            _currentTextLines = todaysAssistantMessage.assistantMessageOptions.assistantDialogues;
            // mainAssistantText.text = string.Empty;
            
            playerTyping.SetActive(true);
            assistantTyping.SetActive(false);

            foreach (var closeButton in myCloseButtons)
            {
                closeButton.gameObject.GetComponent<Button>().interactable = false;
            }
        }

        public void StartDialogue()
        {
            _index = 0;
            StartCoroutine(TypeLine());
        }

        public void StopAllCoroutinesForThis()
        {
            StopAllCoroutines();
        }

        private void Update()
        {
            ShowNextDialogue();

            if (Input.GetMouseButtonDown(0))
            {
                NextLine();
                SoundManager.Instance.PlayAssistantMessageSoundEffect();
            }

            if (_index % 2 == 0)
            {
                SoundManager.Instance.PlayKeyboardTypingSoundEffect();
                assistantTyping.SetActive(false);
                playerTyping.SetActive(true);
            }
            else
            {
                // SoundManager.Instance.PlayAssistantMessageSoundEffect();
                if (!_endDialogue)
                {
                    SoundManager.Instance.StopKeyboardTypingSoundEffect();
                    assistantTyping.SetActive(true);
                    playerTyping.SetActive(false);
                }    
            }

            if (_endDialogue)
            {
                // foreach (var closeButton in myCloseButtons)
                // {
                //     closeButton.gameObject.GetComponent<Button>().interactable = true;
                // }
                myCloseButtons[0].gameObject.GetComponent<Button>().interactable = true;
                myCloseButtons[1].gameObject.GetComponent<Button>().interactable = true;
                myCloseButtons[2].gameObject.GetComponent<Button>().interactable = false;
            }
        }

        public void ShowNextDialogue()
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     if (mainAssistantText.text == _currentTextLines[_index])
            //     {
            //         NextLine();
            //     }
            //     else
            //     {
            //         StopAllCoroutines(); 
            //         mainAssistantText.text = _currentTextLines[_index];
            //     }
            // }
        }
        
        private IEnumerator TypeLine()
        {
            mainAssistantText.text += _currentTextLines[_index];
            yield return new WaitForSeconds(todaysAssistantMessage.assistantMessageOptions.textSpeed);
        }
        
        private void NextLine()
        {
            if (_index < _currentTextLines.Length - 1)
            {
                _index++;
                mainAssistantText.text += "\n";
                
                StartCoroutine(TypeLine());
            }
            else
            {
                EndDialogue();
            }
        }

        private void EndDialogue()
        {
            _endDialogue = true;
            
            assistantTyping.SetActive(false);
            playerTyping.SetActive(false);
            
            StopAllCoroutines();
        }
    }
}
using System;
using System.Collections.Generic;
using UnidosJam.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class DecisionManager : MonoBehaviour
    {
        [SerializeField] private Sprite readMailSprite;
        [SerializeField] private DecisionButton[] buttons;
        
        public List<CharacterScriptableObject> characters;
        
        private int _decisionCount = 0;
        private bool _canGoNextDay = false;

        private GeneralTextPanel _generalTextPanel;
            
        public static DecisionManager Instance { get; private set; }

        public int DecisionCount
        {
            get => _decisionCount;
            set => _decisionCount = value;
        }
        public bool CanGoNextDay => _canGoNextDay;

        public DecisionButton[] Buttons
        {
            get => buttons;
            set => buttons = value;
        }
        public bool CharactersSelected { get; private set; } = false;

        private void Awake()
        {
            SingletonObject();
            
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
            buttons = FindObjectsOfType<DecisionButton>();
            
            characters = new List<CharacterScriptableObject>();
        }

        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        public void PlayerClickYesButton(){

            if (characters.Count >= 2)
            {
                CharactersSelected = true;
                return;
            }

            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();

            // _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
            //     .PlayerDecisions.positiveAnswers++;

            if (characters.Contains(_generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character)) return;
            
            characters.Add(_generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character);
            
            foreach (var characterScriptableObject in characters)
            {
                Debug.Log(characterScriptableObject.name);
            }

            _generalTextPanel.CurrentMailPanel.SetAnswer("From: " + NameManager.PlayerName + "  " + _generalTextPanel.CurrentMailPanel.MailInformationSo
                .playerAnswersToThisMail.PositiveAnswerToThisMail
            );

            _decisionCount++;
        }

        private void Update()
        {
            Debug.Log(_decisionCount);

            if (characters.Count >= 2)
            {
                CharactersSelected = true;
            }
            
            if (_decisionCount >= 2)
            {
                _canGoNextDay = true;
            }

            if (CharactersSelected && !_canGoNextDay)
            {
                foreach (var button in buttons)
                {
                    Debug.Log("GIRDIMMM");
                    if(button != null)
                        button.gameObject.SetActive(false);
                }
            }
        }

        public void ReadMail()
        {
            _generalTextPanel.CurrentMailPanel.GetComponent<Image>().sprite = readMailSprite;
        }
    }
}
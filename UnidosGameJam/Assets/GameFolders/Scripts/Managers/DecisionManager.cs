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
        public bool CanGoNextDayMonologue { get; private set; } = false;

        private GeneralTextPanel _generalTextPanel;
        private NextDayCharacterMonologue _nextDayCharacterMonolog;
        
        public static DecisionManager Instance { get; private set; }

        public int DecisionCount
        {
            get => _decisionCount;
            set => _decisionCount = value;
        }

        public bool CanGoNextDay
        {
            get => _canGoNextDay;
            set => _canGoNextDay = value;
        }

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
            _nextDayCharacterMonolog = FindObjectOfType<NextDayCharacterMonologue>();
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

            _generalTextPanel.CurrentMailPanel.SetAnswer("\n\n" + _generalTextPanel.CurrentMailPanel.MailInformationSo
                .playerAnswersToThisMail.PositiveAnswerToThisMail + "\n"
            );

            _decisionCount++;
                
            if (_decisionCount >= 2)
            {
                CanGoNextDayMonologue = true;
            }
        }

        private void Update()
        {
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
                    if(button != null)
                        button.gameObject.SetActive(false);
                }
            }

            if (CanGoNextDay)
            {
                if (CanGoNextDayMonologue)
                {
                    _nextDayCharacterMonolog.NothingToDoMonologue();
                    // CanGoNextDayMonologue = false;
                }
            }
        }

        public void ReadMail()
        {
            _generalTextPanel.CurrentMailPanel.GetComponent<Image>().sprite = readMailSprite;
        }
    }
}
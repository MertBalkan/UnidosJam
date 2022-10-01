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
        [SerializeField] private DecisionButton[] decisionButtons;
        
        public List<CharacterScriptableObject> characters;

        private GeneralTextPanel _generalTextPanel;
        
        public static DecisionManager Instance { get; private set; }
        
        private void Awake()
        {
            SingletonObject();
            
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
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

        public void PlayerClickNoButton()
        {
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
            
            _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
                .PlayerDecisions.negativeAnswers++;
        }

        public void PlayerClickYesButton()
        {
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
            
            _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
                .PlayerDecisions.positiveAnswers++;

            if (characters.Contains(_generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character)) return;
            
            characters.Add(_generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character);
            
            foreach (var characterScriptableObject in characters)
            {
                Debug.Log(characterScriptableObject.name);
            }

            // _generalTextPanel.CurrentMailPanel.BeforeText +=
            
            
            _generalTextPanel.CurrentMailPanel.SetAnswer(    "From: " + NameManager.PlayerName + "  " + _generalTextPanel.CurrentMailPanel.MailInformationSo
                .playerAnswersToThisMail.PositiveAnswerToThisMail
            );
        }

        public void ReadMail()
        {
            _generalTextPanel.CurrentMailPanel.GetComponent<Image>().sprite = readMailSprite;
        }
    }
}
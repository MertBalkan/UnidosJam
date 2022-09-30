using System.Collections.Generic;
using UnidosJam.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace UnidosJam
{
    public class DecisionManager : MonoBehaviour
    {
        private GeneralTextPanel _generalTextPanel;
        private List<CharacterScriptableObject> _characters;

        public static DecisionManager Instance { get; private set; }
        
        private void Awake()
        {
            SingletonObject();
            _generalTextPanel = FindObjectOfType<GeneralTextPanel>();
            _characters = new List<CharacterScriptableObject>();
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
            _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
                .PlayerDecisions.negativeAnswers++;
        }

        public void PlayerClickYesButton()
        {
            _generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character.characterSettings
                .PlayerDecisions.positiveAnswers++;

            if (_characters.Contains(_generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character)) return;
            
            _characters.Add(_generalTextPanel.CurrentMailPanel.MailInformationSo.mailInformationStruct.character);
            
            foreach (var characterScriptableObject in _characters)
            {
                Debug.Log(characterScriptableObject.name);
            }
        }
    }
}
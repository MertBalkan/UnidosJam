using System;
using System.Collections.Generic;
using UnidosJam.ScriptableObjects;
using UnityEngine;

namespace UnidosJam
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField] private DecisionManager decisionManager;
        
        public List<CharacterScriptableObject> endOfGameCharacters;
        public string[] nextDayStrings;

        public static GameOverManager Instance { get; private set; }
        public string[] NextDayStrings => nextDayStrings;
        
        private void Awake()
        {
            SingletonObject();
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

        public void PrintCharacterStatusToEndOfLevel()
        {
            endOfGameCharacters = DecisionManager.Instance.characters;
            nextDayStrings = new string[endOfGameCharacters.Count];

            for (var index = 0; index < endOfGameCharacters.Count; index++)
            {
                var character = endOfGameCharacters[index];
                var charSettings = character.characterSettings;

                if (!charSettings.isNotrCharacter && (charSettings.playerDecisions.negativeAnswers >=
                                                      charSettings.playerDecisions.positiveAnswers))
                {
                    nextDayStrings[index] = charSettings.playerDecisions.characterNegativeEnding;
                }


                if (!charSettings.isNotrCharacter && (charSettings.playerDecisions.negativeAnswers <
                                                      charSettings.playerDecisions.positiveAnswers))
                {
                    nextDayStrings[index] = charSettings.playerDecisions.characterPositiveEnding;
                }

                if (charSettings.isNotrCharacter)
                {
                    nextDayStrings[index] = charSettings.playerDecisions.characterPositiveEnding;
                }
            }
        }
    }
}
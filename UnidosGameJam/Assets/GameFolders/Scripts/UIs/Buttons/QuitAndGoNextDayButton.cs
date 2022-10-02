using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnidosJam.UIs
{
    public class QuitAndGoNextDayButton : MonoBehaviour
    {
        public bool isEndOfTheGameLevel = false; // Do true end of the game
        private FadeCanvas _fadeCanvas;

        private void Awake()
        {
            _fadeCanvas = FindObjectOfType<FadeCanvas>();
        }

        public void GoNextDay()
        {
            if (DecisionManager.Instance.CanGoNextDay && !isEndOfTheGameLevel)
            {
                _fadeCanvas.StartFade();
                GameManager.Instance.LoadNextSceneWait();
            }

            if (isEndOfTheGameLevel)
            {
                GameOverManager.Instance.PrintCharacterStatusToEndOfLevel();
            }
        }
    }
}
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

            try
            {
                Debug.Log(PositiveNegativeManager.Instance.DecisionCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            if (isEndOfTheGameLevel && PositiveNegativeManager.Instance.DecisionCount >= 2)
            {
                _fadeCanvas.StartFade();
                GameOverManager.Instance.PrintCharacterStatusToEndOfLevel();
            }

            try
            {
                if (PositiveNegativeManager.Instance.CanGoNextDay)
                {
                    _fadeCanvas.StartFade();
                    GameManager.Instance.LoadNextSceneWait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnidosJam.UIs
{
    public class QuitAndGoNextDayButton : MonoBehaviour
    {
        private FadeCanvas _fadeCanvas;

        private void Awake()
        {
            _fadeCanvas = FindObjectOfType<FadeCanvas>();
        }

        public void GoNextDay()
        {
            if (DecisionManager.Instance.CanGoNextDay)
            {
                _fadeCanvas.StartFade();
                GameManager.Instance.LoadNextSceneWait();
            }
        }
    }
}
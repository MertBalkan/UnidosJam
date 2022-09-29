using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class FadeCanvas : MonoBehaviour
    {
        [SerializeField] private CanvasGroup fadeCanvasGroup;
        
        private bool _startFade;

        private void Start()
        {
            fadeCanvasGroup.alpha = 0;
        }

        public void StartFade()
        {
            _startFade = true;
        }

        private void Update()
        {
            if (_startFade)
                fadeCanvasGroup.alpha += Time.deltaTime;

            if (fadeCanvasGroup.alpha >= 1) fadeCanvasGroup.alpha = 1;
        }
    }
}
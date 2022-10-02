using System;
using System.Collections;
using UnityEngine;

namespace UnidosJam
{
    public class FadeOutCanvas : MonoBehaviour
    {
        [SerializeField] private CanvasGroup fadeCanvasGroup;
        
        private bool _startFade;

        private void Start()
        {
            fadeCanvasGroup.alpha = 1;
            // StartFade();
            // StartCoroutine(WaitSec());
        }


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startFade = true;
            }
            
            if (_startFade)
                fadeCanvasGroup.alpha -= Time.deltaTime;

            if (fadeCanvasGroup.alpha < 1) fadeCanvasGroup.alpha = 0;
        }

        private IEnumerator WaitSec()
        {
            yield return new WaitForSeconds(0.5f);
            {
            }
        }
    }   
}
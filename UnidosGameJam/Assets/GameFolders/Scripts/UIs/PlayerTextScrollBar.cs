using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class PlayerTextScrollBar : MonoBehaviour
    {
        private Scrollbar _scrollbar;

        private void Awake()
        {
            _scrollbar = GetComponent<Scrollbar>();
        }

        private void Update()
        {
            if (_scrollbar.value < 0.108f)
            {
                _scrollbar.value = 0.108f;
            }
        }
    }
}
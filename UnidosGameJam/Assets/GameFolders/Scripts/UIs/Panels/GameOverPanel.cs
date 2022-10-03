using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UnidosJam
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] characterEndings;


        private void Update()
        {
            characterEndings[0].text = GameOverManager.Instance.nextDayStrings[0];
            characterEndings[1].text = GameOverManager.Instance.nextDayStrings[1];
        }
    }   
}
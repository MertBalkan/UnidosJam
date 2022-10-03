using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class DecisionDistributor : MonoBehaviour
    {
        public void PlayerClickedYesButton()
        {
            PositiveNegativeManager.Instance.PlayerClickYesButton();
        }

        public void PlayerClickedNoButton()
        {
            PositiveNegativeManager.Instance.PlayerClickNoButton();
        }
    }   
}
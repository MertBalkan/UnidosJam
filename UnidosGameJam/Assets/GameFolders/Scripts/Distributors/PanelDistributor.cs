using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class PanelDistributor : MonoBehaviour
    {
        public void ReadMail()
        {
            PositiveNegativeManager.Instance.ReadMail();
        }
    }   
}
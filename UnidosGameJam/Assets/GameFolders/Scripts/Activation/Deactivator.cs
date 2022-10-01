using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class Deactivator : MonoBehaviour
    {
        void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
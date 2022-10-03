using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnidosJam
{
    public class SoundDistributor : MonoBehaviour
    {
        public void PlayButtonClickSoundEffect()
        {
            SoundManager.Instance.PlayButtonClickSoundEffect();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
 
    public class MusicVolumeSlider : MonoBehaviour
    {
        private Slider _slider;

        public Slider MusicSlider =>_slider;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
    }   
}
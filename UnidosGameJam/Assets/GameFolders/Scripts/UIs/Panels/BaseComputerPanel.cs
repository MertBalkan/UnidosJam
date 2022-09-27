using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam.UIs
{
    public abstract class BaseComputerPanel : MonoBehaviour
    {
        [SerializeField] private Sprite icon;
        private Image _myImage;

        private void Awake()
        {
            _myImage = GetComponent<Image>();
                
            _myImage.sprite = icon;
        }
    }
}
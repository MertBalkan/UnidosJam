using System;
using UnidosJam.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam.UIs
{
    public class BaseButtonUI : MonoBehaviour
    {
        [SerializeField] private ButtonScriptableObject buttonSo;

        private Image _image;
        private int _clickCount;

        public ButtonScriptableObject ButtonSo => buttonSo;
        public Image ButtonImage => _image;

        public int ClickCount
        {
            set => _clickCount = value;
        }
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            _image.sprite = buttonSo.spriteSettings.closeSprite;
            _clickCount = 0;
        }
        
        public void OnSpriteChange()
        {
            _clickCount++;
            
            if (_clickCount >= 2)
                _clickCount = 0;
            
            _image.sprite = _clickCount % 2 != 0 ? buttonSo.spriteSettings.openSprite : buttonSo.spriteSettings.closeSprite;
        }

        public void OpenNewWindow(GameObject windowPanel)
        {
            windowPanel.SetActive(true);

            if (_image.sprite == buttonSo.spriteSettings.closeSprite)
                windowPanel.SetActive(false);
        }
    }
}
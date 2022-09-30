using UnityEngine;

namespace UnidosJam.UIs
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private BaseButtonUI buttonUI;

        public void ChangeSpriteAsClose()
        {
            buttonUI.ButtonImage.sprite = buttonUI.ButtonSo.spriteSettings.closeSprite;
            buttonUI.ClickCount = 0;
        }
    }
}
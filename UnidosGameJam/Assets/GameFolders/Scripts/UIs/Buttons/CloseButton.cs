using System;
using UnityEngine;

namespace UnidosJam.UIs
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private BaseButtonUI buttonUI;

        public void ChangeSpriteAsClose()
        {
            try
            {
                buttonUI.ButtonImage.sprite = buttonUI.ButtonSo.spriteSettings.closeSprite;
                buttonUI.ClickCount = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class NameField : MonoBehaviour
    {
        private readonly string _noName = "Investor";

        [SerializeField] private GameObject confirmButton;
        
        private FadeCanvas _fadeCanvas;

        private void Awake()
        {
            _fadeCanvas = FindObjectOfType<FadeCanvas>();
        }

        public void ReadName()
        {
            var name = GetComponent<TMP_InputField>().text;
            
            NameManager.PlayerName = string.IsNullOrWhiteSpace(name) ? _noName : name;
            _fadeCanvas.StartFade();
            
            GameManager.Instance.LoadNextSceneWait();
            
            confirmButton.SetActive(false);
            Debug.Log(NameManager.PlayerName);
        }
    }
}
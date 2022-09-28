using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class NameField : MonoBehaviour
    {
        private readonly string _noName = "Investor";
        
        public void ReadName()
        {
            var name = GetComponent<TMP_InputField>().text;
            
            NameManager.PlayerName = string.IsNullOrWhiteSpace(name) ? _noName : name;
            
            GameManager.Instance.LoadNextScene();
            Debug.Log(NameManager.PlayerName);
        }
    }
}
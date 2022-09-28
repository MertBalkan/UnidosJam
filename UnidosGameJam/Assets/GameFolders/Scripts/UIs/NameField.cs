using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnidosJam
{
    public class NameField : MonoBehaviour
    {
        public void ReadName()
        {
            NameManager.PlayerName = GetComponent<TMP_InputField>().text;
            Debug.Log(NameManager.PlayerName);
        }
    }
}
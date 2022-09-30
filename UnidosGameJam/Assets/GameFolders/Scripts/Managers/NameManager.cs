using UnityEngine;

namespace UnidosJam
{
    public class NameManager : MonoBehaviour
    {
        public static NameManager Instance { get; private set; }
        
        private void Awake()
        {
            SingletonObject();
        }
        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        public static string PlayerName;
    }
}
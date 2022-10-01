using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnidosJam
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public int CurrentDayCount = 0;
        
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

        public void AssignCharactersToMails(NextDaysMailPanel[] mailPanels)
        {
            for (int i = 0; i < DecisionManager.Instance.characters.Count; i++)
            {
                mailPanels[i].CharacterScriptableObject = DecisionManager.Instance.characters[i];
            }
        }
        
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadNextSceneWait()
        {
            StartCoroutine(LoadNextSceneWaitAsync());
        }
        
        private IEnumerator LoadNextSceneWaitAsync()
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
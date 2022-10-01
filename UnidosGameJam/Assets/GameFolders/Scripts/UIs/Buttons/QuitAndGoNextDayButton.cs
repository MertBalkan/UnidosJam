using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnidosJam.UIs
{
    public class QuitAndGoNextDayButton : MonoBehaviour
    {
        public void GoNextDay()
        {
            if (DecisionManager.Instance.CanGoNextDay)
            {
                Debug.Log("CAN GO NEXT DAY!");
                GameManager.Instance.LoadNextScene();
            }
        }
    }
}
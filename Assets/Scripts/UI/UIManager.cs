using UnityEngine;

namespace JumpNRun
{
    public class UIManager : MonoBehaviour
    {
        public GameObject _gameStartUI;
        public GameObject _gameOverUI;

        private void Start()
        {
            Time.timeScale = 0f;
            _gameStartUI.SetActive(true);
            _gameOverUI.SetActive(false);
        }

        public void StartGame()
        {
            Time.timeScale = 1.0f;
            _gameStartUI.SetActive(false);
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            _gameOverUI.SetActive(true);
        }

        public void Retry()
        {
            Time.timeScale = 1.0f;
            // ¾À ´Ù½Ã ·Îµå
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

    }
}

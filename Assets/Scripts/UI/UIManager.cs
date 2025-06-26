using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace JumpNRun
{
    public class UIManager : MonoBehaviour
    {
        //    public GameObject _gameStartUI;
        //    public GameObject _gameOverUI;

        //    private void Start()
        //    {
        //        Time.timeScale = 0f;
        //        _gameStartUI.SetActive(true);
        //        _gameOverUI.SetActive(false);
        //    }

        //    public void StartGame()
        //    {
        //        Time.timeScale = 1.0f;
        //        _gameStartUI.SetActive(false);
        //    }

        //    public void GameOver()
        //    {
        //        Time.timeScale = 0f;
        //        _gameOverUI.SetActive(true);
        //    }

        //    public void Retry()
        //    {
        //        Time.timeScale = 1.0f;
        //        // 씬 다시 로드
        //        UnityEngine.SceneManagement.SceneManager.LoadScene(
        //            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        //    }

        //}

        public GameObject _loadingUI;
        public Slider _loadingSlider;
        public TMP_Text _loadingPercentText;

        public GameObject _gameStartUI;
        public GameObject _gameOverUI;

        private void Start()
        {
            Time.timeScale = 0f;

            _loadingUI.SetActive(true);      // 로딩 먼저 보이기
            _gameStartUI.SetActive(false);
            _gameOverUI.SetActive(false);

            StartCoroutine(ShowLoadingThenStartUI());
        }

        IEnumerator ShowLoadingThenStartUI()
        {
            float duration = 3f;
            float timer = 0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                float progress = Mathf.Clamp01(timer / duration);

                // 슬라이더 값 및 텍스트 표시
                _loadingSlider.value = progress;
                int percent = Mathf.RoundToInt(progress * 100);
                _loadingPercentText.text = percent + "%";

                yield return null;
            }

            _loadingUI.SetActive(false);
            _gameStartUI.SetActive(true);
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}

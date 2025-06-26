using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace JumpNRun
{
    public class PlayManager : MonoBehaviour
    {
        //[SerializeField] TextMeshProUGUI _timer;
        //[SerializeField] TextMeshProUGUI _finalTimer; 
        //[SerializeField] GameObject _startPanel;
        //[SerializeField] GameObject _overPanel;
        //[SerializeField] GameObject _player;

        //bool _isOver = false;

        //// Start is called once before the first execution of Update after the MonoBehaviour is created
        //void Start()
        //{
        //    Time.timeScale = 0f;
        //    _startPanel.SetActive(true);
        //    _overPanel.SetActive(false);
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    if (!_isOver&&_player==null)
        //    {
        //        _isOver = true;
        //        GameOver();
        //    }
        //}

        //public void StartGame()
        //{
        //    Time.timeScale = 1.0f;
        //    _startPanel.SetActive(false);
        //}

        //public void GameOver()
        //{
        //    //Debug.Log("호출됨");
        //    Time.timeScale = 0f;
        //    _overPanel.SetActive(true);

        //    if (_timer != null)
        //    {
        //        _finalTimer.text = _timer.text;
        //    }

        //}

        //public void Retry()
        //{
        //    Time.timeScale = 1.0f;
        //    // 씬 다시 로드
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(
        //        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        //}


        [Header("UI Panels")]
        [SerializeField] GameObject _loadingPanel;
        [SerializeField] GameObject _startPanel;
        [SerializeField] GameObject _overPanel;

        [Header("Timer UI")]
        [SerializeField] TextMeshProUGUI _timer;
        [SerializeField] TextMeshProUGUI _finalTimer;

        [Header("Loading UI")]
        [SerializeField] Slider _loadingSlider;
        [SerializeField] TextMeshProUGUI _loadingPercentText;

        [Header("Gameplay")]
        [SerializeField] GameObject _player;

        private bool _isOver = false;

        void Start()
        {
            Time.timeScale = 0f;

            // 초기 UI 상태 설정
            _loadingPanel.SetActive(true);
            _startPanel.SetActive(false);
            _overPanel.SetActive(false);

            StartCoroutine(ShowLoadingThenStartPanel());
        }

        void Update()
        {
            // 게임 오버 조건: 플레이어가 사라졌고, 아직 오버 처리 안 했을 때
            if (!_isOver && _player == null)
            {
                _isOver = true;
                GameOver();
            }
        }

        IEnumerator ShowLoadingThenStartPanel()
        {
            float duration = 3f;
            float timer = 0f;

            while (timer < duration)
            {
                timer += Time.unscaledDeltaTime; // 
                float progress = Mathf.Clamp01(timer / duration);
                _loadingSlider.value = progress;

                int percent = Mathf.RoundToInt(progress * 100f);
                _loadingPercentText.text = percent + "%";

                yield return null; // 또는 yield return new WaitForSecondsRealtime(0.01f);
            }

            _loadingPanel.SetActive(false);
            _startPanel.SetActive(true);
        }

        public void StartGame()
        {
            Time.timeScale = 1.0f;
            _startPanel.SetActive(false);
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            _overPanel.SetActive(true);

            if (_timer != null && _finalTimer != null)
            {
                _finalTimer.text = _timer.text;
            }
        }

        public void Retry()
        {
            Time.timeScale = 1.0f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}

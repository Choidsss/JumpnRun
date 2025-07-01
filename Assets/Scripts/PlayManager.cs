using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

        [SerializeField] GameObject _leftButton;
        [SerializeField] GameObject _righttButton;
        [SerializeField] GameObject _jumpButton;

        [SerializeField] TextMeshProUGUI _messageText;           // 텍스트 컴포넌트 (문구 변경용)
        [SerializeField] GameObject _pauseButton;

        [Header("UI Panels")]
        [SerializeField] GameObject _loadingPanel;
        [SerializeField] GameObject _startPanel;
        [SerializeField] GameObject _overPanel;
        [SerializeField] GameObject _settingPanel;

        [Header("Timer UI")]
        [SerializeField] TextMeshProUGUI _timer;
        [SerializeField] TextMeshProUGUI _finalTimer;

        [Header("Loading UI")]
        [SerializeField] Slider _loadingSlider;
        [SerializeField] TextMeshProUGUI _loadingPercentText;

        [Header("Gameplay")]
        [SerializeField] GameObject _player;

        [SerializeField] GameObject _pauseMenuUI;
        
        //[SerializeField] Rigidbody[] _rigidbodies;  // 수동으로 설정

        Coroutine _messageCoroutine;

        //Rigidbody[] _rigidbodies;

        bool _isOver = false;
        bool isPaused = false;
        //bool SkipLoadingOnRetry = false;     //true;
        static bool SkipLoadingOnRetry = false;

        void Start()
        {
            //Time.timeScale = 0f;

            //// 초기 UI 상태 설정
            //_loadingPanel.SetActive(true);
            //_startPanel.SetActive(false);
            //_overPanel.SetActive(false);

            //StartCoroutine(ShowLoadingThenStartPanel());

            Time.timeScale = 0f;

                _loadingPanel.SetActive(true);
                _pauseButton.SetActive(false); // 처음엔 버튼 숨기기
                _startPanel.SetActive(false);
                _overPanel.SetActive(false);
                _settingPanel.SetActive(false);
                _messageText.gameObject.SetActive(false);
                _pauseMenuUI.SetActive(false);
                _leftButton.SetActive(false);
                _righttButton.SetActive(false);
                _jumpButton.SetActive(false);

                if (SkipLoadingOnRetry)
                {
                    _loadingPanel.SetActive(false);
                    _startPanel.SetActive(true);
                    SkipLoadingOnRetry = false;
                    return;
                }


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
            _pauseButton.SetActive(true);   // 게임 시작 시 Pause 버튼 보이게
            _leftButton.SetActive(true);
            _righttButton.SetActive(true);
            _jumpButton.SetActive(true);
                
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            _overPanel.SetActive(true);
            _pauseButton.SetActive(false);
            _leftButton.SetActive(false);
            _righttButton.SetActive(false);
            _jumpButton.SetActive(false);

            if (_timer != null && _finalTimer != null)
            {
                _finalTimer.text = _timer.text;
            }

            // 메시지 자동 호출 안 함
            // 필요하면 유저가 버튼 누를 때 ShowMessage() 호출
        }

        public void Retry()
        {
            Time.timeScale = 1.0f;
            SkipLoadingOnRetry = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        public void TogglePause()
        {
            if (_pauseButton.activeSelf == false)
                return;  // 버튼 비활성 상태면 무시

            // 버튼은 눌러도 끄지 말고, 클릭 막는 용도로 쓰지 않는다면 이 라인 삭제 가능
            //_pauseButton.SetActive(false); 

            if (!isPaused)
            {
                // 일시정지 시작
                isPaused = true;
                Time.timeScale = 0f;

                _pauseMenuUI.SetActive(true);
                _startPanel.SetActive(false); // Pause 시 Start 패널 꺼짐

                //PausePhysics();
            }
            else
            {
                // 일시정지 해제
                isPaused = false;
                Time.timeScale = 1f;

                _pauseMenuUI.SetActive(false);
                _startPanel.SetActive(false); // Resume 시 Start 패널도 꺼둠, 게임 플레이 화면 유지

                //ResumePhysics();
            }

            AudioListener.pause = isPaused;

            // 버튼 다시 비활성화/활성화 코루틴은 제거해도 무방
            //StartCoroutine(ReenablePauseButtonAfterDelay(0.5f));
        }

        /*
        IEnumerator ReenablePauseButtonAfterDelay(float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            _pauseButton.SetActive(true);
        }
        */


        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1f;
            _pauseMenuUI.SetActive(false);   // Pause 메뉴 끄기

            _startPanel.SetActive(false);    // Start 패널 끄기

            // 게임 플레이 화면 활성화 (예: 플레이어 UI나 HUD 패널)
            // 만약 따로 게임 UI 패널이 없다면 플레이어 오브젝트 활성화 등으로 대체하세요
            // 예시:
            // _gameplayUI.SetActive(true);

            AudioListener.pause = false;
        }

        public void OpenSettings()
        {
            _settingPanel.SetActive(true);
            _startPanel.SetActive(false);
        }

        public void CloseSettings()
        {
            _settingPanel.SetActive(false);
            _startPanel.SetActive(true);
        }

        public void ShowMessageIfNotOver(string message)
        {
            if (_isOver)
            {
                // 게임 오버 상태면 메시지 띄우기 안 함
                return;
            }

            ShowMessage(message);
        }

        public void ShowMessage(string message)
        {
            _messageText.text = message;

            if (_messageCoroutine != null)
                StopCoroutine(_messageCoroutine);

            _messageCoroutine = StartCoroutine(ShowMessageCoroutine());
        }

        private IEnumerator ShowMessageCoroutine()
        {
            _messageText.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(1.5f);
            _messageText.gameObject.SetActive(false);
            _messageCoroutine = null;
        }

        //void PausePhysics()
        //{
        //    foreach (Rigidbody rb in _rigidbodies)
        //    {
        //        if (rb != null)
        //        {
        //            rb.isKinematic = true;
        //            // velocity 저장 및 복원 API가 없으면 여기서 포기
        //        }
        //    }
        //}

        //void ResumePhysics()
        //{
        //    foreach (Rigidbody rb in _rigidbodies)
        //    {
        //        if (rb != null)
        //        {
        //            rb.isKinematic = false;
        //            // velocity 복원 불가능하면 그냥 물리 다시 활성화
        //        }
        //    }
        //}

    }
}

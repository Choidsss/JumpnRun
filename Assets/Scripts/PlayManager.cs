using TMPro;
using UnityEngine;

namespace JumpNRun
{
    public class PlayManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _timer;
        [SerializeField] TextMeshProUGUI _finalTimer; 
        [SerializeField] GameObject _startPanel;
        [SerializeField] GameObject _overPanel;
        [SerializeField] GameObject _player;

        bool _isOver = false;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Time.timeScale = 0f;
            _startPanel.SetActive(true);
            _overPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (!_isOver&&_player==null)
            {
                _isOver = true;
                GameOver();
            }
        }

        public void StartGame()
        {
            Time.timeScale = 1.0f;
            _startPanel.SetActive(false);
        }

        public void GameOver()
        {
            //Debug.Log("»£√‚µ ");
            Time.timeScale = 0f;
            _overPanel.SetActive(true);

            if (_timer != null)
            {
                _finalTimer.text = _timer.text;
            }
            
        }

        public void Retry()
        {
            Time.timeScale = 1.0f;
            // æ¿ ¥ŸΩ√ ∑ŒµÂ
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}

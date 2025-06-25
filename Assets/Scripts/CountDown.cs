using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace JumpNRun
{
    public class CountDown : MonoBehaviour
    {
        float _timer = 0f;

        public TextMeshProUGUI _timeText;
        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(_timer / 60);
            int seconds = Mathf.FloorToInt(_timer % 60);

            _timeText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace JumpNRun
{
    public class AudioManager : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public Slider volumeSlider;

        void Start()
        {
            // 슬라이더가 연결되어 있다면 초기화
            if (volumeSlider != null)
            {
                // 기본값 설정 (중간 볼륨 예시)
                volumeSlider.minValue = -80f;
                volumeSlider.maxValue = 0f;
                volumeSlider.value = -10f;

                // AudioMixer에 적용
                audioMixer.SetFloat("MasterVolume", volumeSlider.value);

                // 이벤트 연결
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("MasterVolume", volume);

            // -80 이하일 때 사실상 무음 처리
            AudioListener.pause = (volume <= -80f);
        }
    }
}

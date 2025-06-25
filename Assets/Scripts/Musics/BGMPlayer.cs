using UnityEngine;

namespace JumpNRun
{
    public class BGMPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource _audio; 
        [SerializeField] AudioClip[] _audioClip;

        int _currentIndex = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (_audio != null && _audioClip.Length>0)
            {
                PlayCurrentClip();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!_audio.isPlaying)
            {
                NextTrack();
            }

        }

        void PlayCurrentClip()
        {
            _audio.clip = _audioClip[_currentIndex];
            _audio.Play();
        }

        void NextTrack()
        {
            if (_audioClip.Length == 0) return;

            int nextIndex = Random.Range(0, _audioClip.Length);

            // 현재 곡과 같은 인덱스일 경우 다시 뽑기 (중복 방지, 선택사항)
            while (_audioClip.Length > 1 && nextIndex == _currentIndex)
            {
                nextIndex = Random.Range(0, _audioClip.Length);
            }

            _currentIndex = nextIndex;
            PlayCurrentClip();
        }

    }
}

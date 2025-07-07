using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

namespace JumpNRun
{
    public class ADManager : MonoBehaviour
    {
        [SerializeField] GameObject _overPanel;
        [SerializeField] Button _startButton;

        BannerView _bannerview;

        //테스트용 적응형 배너: ca-app-pub-3940256099942544/9214589741
        //광고배너:"ca-app-pub-2692114820896098/4440518824"
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // MobileAds.Initialize(initstatus => { });

            //광고단위 ID넣기
            string adUnitID = "ca-app-pub-3940256099942544/9214589741";

            //배너 광고 생성, ex)위치는 하단
            _bannerview = new BannerView(adUnitID, AdSize.Banner, AdPosition.Top);

            //SDK 버전의 호환 문제 : 다른 SDK 깔아서 해보기
            //광고 요청 생성
            AdRequest request = new AdRequest();

            //광고 로드
            _bannerview.LoadAd(request);

            // 초기에는 광고 숨김
            _bannerview.Hide();

            // Start 버튼 클릭 이벤트 연결
            _startButton.onClick.AddListener(OnStartGame);
        }


        void Update()
        {
            // GameOver 판넬이 활성화되면 광고 숨김
            if (_overPanel.activeSelf)
            {
                HideBannerAd();
            }
        }

        void OnStartGame()
        {
            // 게임 시작 처리 등 필요 시 _playManager.StartGame() 등 호출

            ShowBannerAd();
        }

        public void ShowBannerAd()
        {
            if (_bannerview != null)
            {
                _bannerview.Show();
            }
        }

        public void HideBannerAd()
        {
            if (_bannerview != null)
            {
                _bannerview.Hide();
            }
        }
    }
}

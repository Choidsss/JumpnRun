using UnityEngine;
using GoogleMobileAds.Api;

namespace JumpNRun
{
    public class ADManager : MonoBehaviour
    {
        BannerView _bannerview;

        //테스트용 적응형 배너: ca-app-pub-3940256099942544/9214589741
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // MobileAds.Initialize(initstatus => { });

            //광고단위 ID넣기
            string adUnitID = "ca-app-pub-3940256099942544/9214589741";

            //배너 광고 생성, ex)위치는 하단
            _bannerview = new BannerView(adUnitID, AdSize.Banner, AdPosition.Bottom);

            //SDK 버전의 호환 문제 : 다른 SDK 깔아서 해보기
            //광고 요청 생성
            AdRequest request = new AdRequest();

            //광고 로드
            _bannerview.LoadAd(request);   
        }

    }
}

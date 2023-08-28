//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
////using GoogleMobileAds.Api;
//public class ggAdmob : MonoBehaviour
//{
//    private BannerView bannerView;

//    private RewardedAd rewardedAd;

//    public void Start()
//    {
//        // Initialize the Google Mobile Ads SDK.
//        MobileAds.Initialize(initStatus => { });

//        this.RequestBanner();

//        this.RequestRewarded();
//       // UserChoseToWatchAd();
//    }

//    private void RequestBanner()
//    {
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
//#elif UNITY_IPHONE
//            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
//#else
//            string adUnitId = "unexpected_platform";
//#endif

//        // Create a 320x50 banner at the top of the screen.
//        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();

//        // Load the banner with the request.
//        this.bannerView.LoadAd(request);
//    }


//    public void RequestRewarded()
//    {
//        string adUnitId = "ca-app-pub-3940256099942544/5224354917";

//        this.rewardedAd = new RewardedAd(adUnitId);

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();
//        // Load the rewarded ad with the request.
//        this.rewardedAd.LoadAd(request);

       
//    }
//    public void UserChoseToWatchAd()
//    {
//        if (this.rewardedAd.IsLoaded())
//        {
//            this.rewardedAd.Show();
//        }
//    }

    
//}
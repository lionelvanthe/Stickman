using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class testironsoure : MonoBehaviour
{
    //    public static testironsoure Instance;
    //    /*
    //     * testID: 85460dcd
    //     * realID: 1097bf53d
    //     */
    //    //private string ironsoure_app_key = "1097bf53d";
    //    private Action<bool> acInterClosed, acRewarded;
    //    public Action acRewardClose;

    //    public Text rewardstatusTxt;
    //    //public Text checkConect;

    //    private void Awake()
    //    {
    //        if (Instance == null)
    //        {
    //            Instance = this;
    //            DontDestroyOnLoad(this);


    //        }
    //        else
    //        {
    //            Destroy(this);
    //        }
    //    }
    //    private void Start()
    //    {
    //        InitAds();
    //    }

    //    private void Update()
    //    {
    //        rewardstatusTxt.text = IronSource.Agent.isRewardedVideoAvailable().ToString();
    //    }
    //    private void OnEnable()
    //    {
    //        /** Interstitial Event*/
    //        IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
    //        IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;
    //        IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent;
    //        IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailedEvent;
    //        IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
    //        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
    //        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;


    //        /** Video Reward Event*/
    //        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
    //        //IronSourceEvents.onRewardedVideoAdClickedEvent += RewardedVideoAdClickedEvent;
    //        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent;
    //        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
    //        IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
    //        IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
    //        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent;
    //        IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;
    //    }

    //    private void InitAds()
    //    {
    //        IronSource.Agent.init("11ee4eee5");
    //        IronSource.Agent.validateIntegration();

    //        ///Admob
    //        IronSource.Agent.setMetaData("AdMob_TFCD", "false");
    //        IronSource.Agent.setMetaData("AdMob_TFUA", "false");
    //        ///Applovin
    //        IronSource.Agent.setMetaData("AppLovin_AgeRestrictedUser", "true");
    //        ///Facebook
    //        IronSource.Agent.setMetaData("Facebook_IS_CacheFlag", "IMAGE");

    //        //AdConoly
    //        IronSource.Agent.setMetaData("AdColony_COPPA", "true");
    //        IronSource.Agent.setMetaData("AdColony_COPPA", "false");
    //        //IronSource.Agent.setAdaptersDebug(true);

    //        InitInterstitial();
    //        InitRewarded();
    //        InitBanner();
    //    }
    //    #region Video Reward
    //    bool rewardedVideoAvailability;
    //    void InitRewarded()
    //    {
    //        IronSource.Agent.shouldTrackNetworkState(true);
    //    }
    //    public void ShowRewardedVideo(Action<bool> _ac)
    //    {
    //        if (rewardedVideoAvailability)
    //        {
    //            acRewarded = _ac;
    //            IronSource.Agent.showRewardedVideo();
    //        }
    //    }

    //    //Invoked when the RewardedVideo ad view has opened.
    //    //Your Activity will lose focus. Please avoid performing heavy 
    //    //tasks till the video ad will be closed.
    //    void RewardedVideoAdOpenedEvent()
    //    {
    //    }
    //    //Invoked when the RewardedVideo ad view is about to be closed.
    //    //Your activity will now regain its focus.
    //    void RewardedVideoAdClosedEvent()
    //    {
    //        if (acRewarded != null)
    //        {
    //            acRewarded(false);
    //        }
    //    }
    //    //Invoked when there is a change in the ad availability status.
    //    //@param - available - value will change to true when rewarded videos are available. 
    //    //You can then show the video by calling showRewardedVideo().
    //    //Value will change to false when no videos are available.
    //    void RewardedVideoAvailabilityChangedEvent(bool available)
    //    {
    //        //Change the in-app 'Traffic Driver' state according to availability.
    //        rewardedVideoAvailability = available;
    //    }

    //    //Invoked when the user completed the video and should be rewarded. 
    //    //If using server-to-server callbacks you may ignore this events and wait for 
    //    // the callback from the  ironSource server.
    //    //@param - placement - placement object which contains the reward data
    //    void RewardedVideoAdRewardedEvent(IronSourcePlacement placement)
    //    {
    //        if (acRewarded != null)
    //        {
    //            acRewarded(true);
    //        }
    //    }
    //    //Invoked when the Rewarded Video failed to show
    //    //@param description - string - contains information about the failure.
    //    void RewardedVideoAdShowFailedEvent(IronSourceError error)
    //    {
    //    }

    //    // ----------------------------------------------------------------------------------------
    //    // Note: the events below are not available for all supported rewarded video ad networks. 
    //    // Check which events are available per ad network you choose to include in your build. 
    //    // We recommend only using events which register to ALL ad networks you include in your build. 
    //    // ----------------------------------------------------------------------------------------

    //    //Invoked when the video ad starts playing. 
    //    void RewardedVideoAdStartedEvent()
    //    {
    //    }
    //    //Invoked when the video ad finishes playing. 
    //    void RewardedVideoAdEndedEvent()
    //    {
    //    }
    //    //Invoked when the video ad is clicked. 
    //    void RewardedVideoAdClickedEvent()
    //    {
    //    }


    //    #endregion
    //    #region Interstitial
    //    void InitInterstitial()
    //    {
    //        IronSource.Agent.loadInterstitial();
    //    }
    //    public void ShowInterstitial()
    //    {
    //        //if (GameData.Instance != null)
    //        //{
    //        //    if (!GameData.Instance.NO_ADS)
    //        //    {
    //        //        if (IronSource.Agent.isInterstitialReady())
    //        //        {
    //        //            IronSource.Agent.showInterstitial();
    //        //        }
    //        //        else
    //        //        {
    //        //            IronSource.Agent.loadInterstitial();
    //        //        }
    //        //    }
    //        //}
    //        //else
    //        //{
    //        if (IronSource.Agent.isInterstitialReady())
    //        {
    //            IronSource.Agent.showInterstitial();
    //        }
    //        else
    //        {
    //            IronSource.Agent.loadInterstitial();
    //        }
    //        // }
    //    }
    //    #region Interstitial Handler
    //    // Invoked when the initialization process has failed.
    //    // @param description - string - contains information about the failure.
    //    void InterstitialAdLoadFailedEvent(IronSourceError error)
    //    {
    //    }
    //    // Invoked when the ad fails to show.
    //    // @param description - string - contains information about the failure.
    //    void InterstitialAdShowFailedEvent(IronSourceError error)
    //    {
    //    }
    //    // Invoked when end user clicked on the interstitial ad
    //    void InterstitialAdClickedEvent()
    //    {
    //    }
    //    // Invoked when the interstitial ad closed and the user goes back to the application screen.
    //    void InterstitialAdClosedEvent()
    //    {
    //        if (acInterClosed != null)
    //            acInterClosed(true);
    //        IronSource.Agent.loadInterstitial();
    //    }
    //    // Invoked when the Interstitial is Ready to shown after load function is called
    //    void InterstitialAdReadyEvent()
    //    {
    //    }
    //    // Invoked when the Interstitial Ad Unit has opened
    //    void InterstitialAdOpenedEvent()
    //    {
    //    }
    //    // Invoked right before the Interstitial screen is about to open.
    //    // NOTE - This event is available only for some of the networks. 
    //    // You should treat this event as an interstitial impression, but rather use InterstitialAdOpenedEvent
    //    void InterstitialAdShowSucceededEvent()
    //    {
    //    }

    //    #endregion
    //    #endregion

    //    #region Banner
    //    private void InitBanner()
    //    {
    //        IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
    //    }

    //    public void ShowBanner()
    //    {
    //        IronSource.Agent.displayBanner();
    //    }
    //    public void HideBanner()
    //    {
    //        IronSource.Agent.hideBanner();
    //    }
    //    #endregion

    //    void OnApplicationPause(bool isPaused)
    //    {
    //        IronSource.Agent.onApplicationPause(isPaused);
    //    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class AdMobController : MonoBehaviour {
	private static BannerView bannerView;

    public static void initialize() {
        string apiId;
		if (Application.platform == RuntimePlatform.Android) {
			apiId = "ca-app-pub-5830175342552944~6165246779";
		}
		else {
			// @TODO Need to set this if ever deployed on iOS
			apiId = "ca-app-pub-5830175342552944~6165246779";
		}
		MobileAds.Initialize(apiId);
    }

    public static void requestBanner()
    {
        string adUnitId;
		if (Application.platform == RuntimePlatform.Android) {
			adUnitId = "ca-app-pub-5830175342552944/9397914773";
		}
		else {
			// @TODO Need to set this if ever deployed on iOS
			adUnitId = "ca-app-pub-5830175342552944/9397914773";
		}

        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
    }

    public static void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }
}
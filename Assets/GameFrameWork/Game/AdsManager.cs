using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;
//using UnityEngine.Advertisements;


namespace GFW
{
	public class AdsManager :  ServiceModule<AdsManager> 
	{

		string gpGameID = "1598965";
		string iosGameID = "1598966";

		AdmobManager m_admobMgr;

		public AdsManager()
		{
			m_admobMgr = new AdmobManager ();
		}

		public void Init()
		{
			//if (Advertisement.isSupported) 
			{
			//	Advertisement.Initialize (gpGameID, true);
			}

			m_admobMgr.Init ();

		}

		public void Destory()
		{
		}

		public void Clear()
		{
		}

//		public bool AdsIsReady()
//		{
//			return Advertisement.IsReady();
//		}
//			
//		public void ShowAd()
//		{
//
//			if (Advertisement.IsReady ())
//				Advertisement.Show ();
//
//			return;
//
//
//			if(Advertisement.IsReady("rewardedVideo")) {
//				var options = new ShowOptions();
//				options.resultCallback = HandleShowResult;
//				Advertisement.Show("rewardedVideo", options);
//			}else{
//				Debug.Log("Rewarded Video not available");
//			}
//		}
//
//		//HandleShowResult will be called when the ad stops playing, and pass the result enumerator
//		void HandleShowResult (ShowResult result)
//		{
//			if(result == ShowResult.Finished) {
//				Debug.Log("Video completed - Offer a reward to the player");
//
//			}else if(result == ShowResult.Skipped) {
//				Debug.LogWarning("Video was skipped - Do NOT reward the player");
//
//			}else if(result == ShowResult.Failed) {
//				Debug.LogError("Video failed to show");
//			}
//		}


		public void ShowBanner()
		{
			m_admobMgr.ShowBanner ();
		}

		public void RemoveBanner()
		{
			m_admobMgr.RemoveBanner ();
		}

		public void ShowBannerABS(int x, int y)
		{
			m_admobMgr.ShowBannerABS (x, y);
		}

		public void ShowInterstitial()
		{
			m_admobMgr.ShowInterstitial ();
		}



	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdmobManager //: MonoBehaviour 
{
	// Use this for initialization
	void Start ()
	{		
		Init ();
	}

	// Update is called once per frame
	void Update () 
	{
	}

	public void Init()
	{
		Admob.Instance().initAdmob("ca-app-pub-8622886418935922/3144013299", "ca-app-pub-8622886418935922/4332083838");
		Admob.Instance ().loadInterstitial();
		//m_admob.setGender (AdmobGender.MALE);
		Admob.Instance().bannerEventHandler += onBannerEvent;
	}

	public void ShowBanner()
	{
		Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
	}

	public void RemoveBanner()
	{
		Admob.Instance().removeBanner ();
	}

	public void ShowBannerABS(int x, int y)
	{
		Admob.Instance ().showBannerAbsolute (AdSize.Banner, x, y);
	}

	void onBannerEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
	}

	public void ShowInterstitial()
	{
		if(Admob.Instance ().isInterstitialReady())
		{
			Admob.Instance ().showInterstitial();
		}
		else
		{
			Admob.Instance ().loadInterstitial();
		}
	}


}

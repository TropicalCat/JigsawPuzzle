using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class admobDemoo : MonoBehaviour 
{

	// Use this for initialization
	void Start () {

		Admob.Instance ().initAdmob ("ca-app-pub-8622886418935922/3144013299", "ca-app-pub-8622886418935922/4332083838");

		//Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnGUI(){
		
		if (GUI.Button(new Rect(500, 500, 200, 100), "showbanner"))
		{
			Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
		}

		if (GUI.Button(new Rect(240, 100, 100, 60), "removebanner"))
		{
			Admob.Instance().removeBanner();
		}

	}
}

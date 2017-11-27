using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	/// <summary>
	/// 因为一个battle打不开battle，修改loading为page。
	/// </summary>
	public class UILoadingWnd : UIPage
	{
		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);



			//ads
			//GFW.AdsManager.Instance.ShowInterstitial ();


			//ads
			GFW.AdsManager.Instance.ShowBannerABS (70, 1300);


			StartCoroutine (Loading());
		}

		IEnumerator Loading()
		{
			yield return new WaitForSeconds (1f);
			LoadFinish ();
		}

		protected override void OnClose(object arg = null)
		{
			base.OnClose (arg);
			GFW.AdsManager.Instance.RemoveBanner();
		}

		private void LoadFinish()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.LoadingModule) as LoadingModule;
			if (module != null)
			{
				module.OnLoadingFinish();
			}
		}

	}
}


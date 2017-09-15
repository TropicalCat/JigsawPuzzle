using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class UILoadingPage : UIPage
	{
		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);

			StartCoroutine (Loading());
		}

		IEnumerator Loading()
		{
			yield return new WaitForSeconds (1f);
			LoadFinish ();
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

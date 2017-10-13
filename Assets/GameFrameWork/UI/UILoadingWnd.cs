using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class UILoadingWnd : UIWindow
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

		protected override void OnClose(object arg = null)
		{
			base.OnClose (arg);
//			UIManager.Instance.CloseWindow (this);
//			//销毁掉窗口
//			Destroy (gameObject);
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


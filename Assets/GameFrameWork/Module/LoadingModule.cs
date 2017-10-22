using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class LoadingModule : BusinessModule
	{
		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UILoading);
		}
			
		//加载完成
		public void OnLoadingFinish()
		{
			//ModuleManager.Instance.ShowModule (ModuleDef.HomeModule);

			//将登录成功事件通知给整个游戏
			//GlobalEvent.onLogin.Invoke(true);

			//UIManager.Instance.EnterMainPage ();

			GameManager.Instance.StartBattle ();
		}
			
	}
	
}



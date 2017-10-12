using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;


namespace GFW
{
	public class HomeModule : BusinessModule 
	{

		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UIHome);
		}

		public void OpenModule(string name, object arg)
		{
			switch (name)
			{
			case ModuleDef.SelectLevelModule:
				ModuleManager.Instance.ShowModule(name, arg);
				break;
			default:
				//UIAPI.ShowMsgBox(name, "模块正在开发中...", "确定");
				break;
			}
		}


	}
}



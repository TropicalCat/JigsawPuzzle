using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UIHomePage :  UIPage 
	{
		[SerializeField]
		private Button m_btnStart;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
			if (m_btnStart != null)
			{
				m_btnStart.onClick.AddListener(OnStart);
			}
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnStart != null)
			{
				m_btnStart.onClick.RemoveAllListeners();
			}
			base.OnClose (arg);
			//销毁掉窗口
			Destroy (gameObject);
		}

		private void OnStart()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.HomeModule) as HomeModule;
			if (module != null)
			{
				module.OpenModule(ModuleDef.SelectLevelModule, null);
			}	
		}
			

	}
}


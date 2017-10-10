using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;

namespace GFW
{

	public class UIResultPage : UIPage
	{

		[SerializeField]
		private Button m_btnRestart;

		[SerializeField]
		private Button m_btnNext;

		[SerializeField]
		private Button m_btnHome;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);


			if (m_btnRestart != null)
			{
				m_btnRestart.onClick.AddListener(OnRestart);
			}
			if (m_btnNext != null)
			{
				m_btnNext.onClick.AddListener(OnNext);
			}
			if (m_btnHome != null)
			{
				m_btnHome.onClick.AddListener(OnHome);
			}
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnRestart != null)
			{
				m_btnRestart.onClick.RemoveAllListeners();
			}

			if (m_btnNext != null)
			{
				m_btnNext.onClick.RemoveAllListeners();
			}

			if (m_btnHome != null)
			{
				m_btnHome.onClick.RemoveAllListeners();
			}


			base.OnClose (arg);
			//销毁掉窗口
			Destroy (gameObject);
		}

		private void OnRestart()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.ResultModule) as ResultModule;
			if (module != null)
			{
				module.OnRestart();
			}	
			
		}

		private void OnNext()
		{
		}

		private void OnHome()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.ResultModule) as ResultModule;
			if (module != null)
			{
				module.OnHome();
			}	
		}

	
	}
}

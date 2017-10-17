﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UIQuitBattleWnd : UIWindow 
	{
		[SerializeField]
		private Button m_btnCofirm;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);

			if (m_btnCofirm != null)
			{
				m_btnCofirm.onClick.AddListener(OnConfirm);
			}
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnCofirm != null)
			{
				m_btnCofirm.onClick.RemoveAllListeners();
			}

			base.OnClose (arg);
		}


		public void OnCancel()
		{
		}

		public void OnConfirm()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.QuitBattleModule) as QuitBattleModule;
			if (module != null)
			{
				module.OnQuitBattle();
			}
			AudioManager.Instance.PlayClick ();
		}



	}
}


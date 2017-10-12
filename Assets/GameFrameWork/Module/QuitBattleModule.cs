using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;


namespace GFW
{
	public class QuitBattleModule : BusinessModule 
	{
		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenWindow (UIDef.UIQuitBattle);
			if (null != arg) 
			{
				//string s = arg.ToString();
			}
		}
			
		public void OnQuitBattle()
		{
			UIManager.Instance.EnterMainPage ();	
		}

	
	}

}


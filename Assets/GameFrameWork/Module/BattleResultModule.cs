using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;


namespace GFW
{
	public class BattleResultModule : BusinessModule
	{

		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UIBattleResult);
			//string s = arg.ToString();
		}

		//重新开始战斗
		public void OnRestart()
		{
			GameManager.Instance.RestartBattle ();
		}

		public void OnHome()
		{
			UIManager.Instance.EnterMainPage ();
		}

		public void OnNext()
		{
			GameManager.Instance.StartNextBattle ();
		}


	}
}

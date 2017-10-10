﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;


namespace GFW
{
	public class ResultModule : BusinessModule
	{

		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UIResult);
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





	}

}
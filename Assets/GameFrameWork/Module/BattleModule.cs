using UnityEngine;
using System.Collections;
using GE;


namespace GFW
{
	public class BattleModule : BusinessModule
	{

		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UIBattle);
			//int level = arg as int;
			string s = 
			arg.ToString();
		}


	}
	
}



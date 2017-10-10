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
			if (null != arg) 
			{
				//string s = arg.ToString();
			}
		}





	}
	
}



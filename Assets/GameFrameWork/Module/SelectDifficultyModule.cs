using UnityEngine;
using System.Collections;
using GE;


namespace GFW
{

	public class SelectDifficultyModule : BusinessModule
	{

		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UISelectDifficulty);
		}

		public void OnStartBattle(int level, int difficulty)
		{
			ModuleManager.Instance.ShowModule(ModuleDef.BattleModule, level);	

		}
	}



}


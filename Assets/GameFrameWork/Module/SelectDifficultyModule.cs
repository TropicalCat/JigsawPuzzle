using UnityEngine;
using System.Collections;
using GE;


namespace GFW
{

	public class SelectDifficultyModule : BusinessModule
	{
		string selectLevel;
		protected override void Show(object arg)
		{
			base.Show (arg);
			selectLevel = arg.ToString ();
			UIManager.Instance.OpenPage(UIDef.UISelectDifficulty);

		}

		public void OnStartBattle(int level, int difficulty)
		{
			ModuleManager.Instance.ShowModule(ModuleDef.BattleModule, level);	

		}
	}



}


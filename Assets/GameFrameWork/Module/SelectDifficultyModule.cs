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
			//string selectLevel = arg.ToString ();
			UIManager.Instance.OpenWindow(UIDef.UILevelDetails);
		}

		public void OnStartBattle(int level, int difficulty)
		{
			//ModuleManager.Instance.ShowModule(ModuleDef.BattleModule, level);	
			PieceManager.Instance.PieceCount = 4;
			ModuleManager.Instance.ShowModule (ModuleDef.LoadingModule);
		}
	}



}


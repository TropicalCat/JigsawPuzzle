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

			switch (PieceManager.Instance.PieceCount) 
			{
			case 4:
				UIManager.Instance.OpenPage(UIDef.UIBattle4Master);
				break;
			case 9:
				UIManager.Instance.OpenPage(UIDef.UIBattle9Master);
				break;
			default:
				break;
			}
		}

		public void OnQuitBattle()
		{
			ModuleManager.Instance.ShowModule(ModuleDef.QuitBattleModule);
		}



	}
	
}



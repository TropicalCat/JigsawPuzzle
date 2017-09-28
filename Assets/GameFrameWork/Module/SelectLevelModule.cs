using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class SelectLevelModule : BusinessModule
	{
		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenPage(UIDef.UISelectLevel);
		}

		public void OnSelectLevel(int level)
		{
			PieceManager.Instance.SetLevel (level);
			ModuleManager.Instance.ShowModule(ModuleDef.SelectDifficultyModule, level);	
		}
	}
}



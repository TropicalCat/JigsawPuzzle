using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UISelectDifficultyPage:UIPage 
	{
		[SerializeField]
		private Button m_btnStart;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);

			if (m_btnStart != null)
			{
				m_btnStart.onClick.AddListener(OnStart);
			}

			initPiece ();
		}


		void initPiece()
		{
			string pth = PieceManager.Instance.GetCurIllustration ();
			Image image = gameObject.transform.Find ("Preview").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnStart != null)
			{
				m_btnStart.onClick.RemoveAllListeners();
			}
			base.OnClose (arg);
		}
			
		private void OnStart()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.SelectDifficultyModule) as SelectDifficultyModule;
			if (module != null)
			{
				module.OnStartBattle (0,0);
			}	
		}
	}
}
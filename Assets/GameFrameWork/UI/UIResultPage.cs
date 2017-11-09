using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;

namespace GFW
{

	public class UIResultPage : UIPage
	{

		[SerializeField]
		private Button m_btnRestart;

		[SerializeField]
		private Button m_btnNext;

		[SerializeField]
		private Button m_btnHome;

		[SerializeField]
		private GameObject m_aniSparkle;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);

			if (m_btnRestart != null)
			{
				m_btnRestart.onClick.AddListener(OnRestart);
			}
			if (m_btnNext != null)
			{
				m_btnNext.onClick.AddListener(OnNext);
			}
			if (m_btnHome != null)
			{
				m_btnHome.onClick.AddListener(OnHome);
			}

			initPiece ();

			//Animator ani = m_aniSparkle.GetComponent<Animator> ();


			//ani.Play ("Stop");





		}

		void initPiece()
		{
			string pth = PieceManager.Instance.GetCurIllustration ();
			Image image = gameObject.transform.Find ("Preview").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnRestart != null)
			{
				m_btnRestart.onClick.RemoveAllListeners();
			}

			if (m_btnNext != null)
			{
				m_btnNext.onClick.RemoveAllListeners();
			}

			if (m_btnHome != null)
			{
				m_btnHome.onClick.RemoveAllListeners();
			}


			base.OnClose (arg);
			//销毁掉窗口
			Destroy (gameObject);
		}

		private void OnRestart()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.BattleResultModule) as BattleResultModule;
			if (module != null)
			{
				module.OnRestart();
			}
			AudioManager.Instance.PlayClick ();
		}

		private void OnNext()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.BattleResultModule) as BattleResultModule;
			if (module != null)
			{
				module.OnNext();
			}
			AudioManager.Instance.PlayClick ();
		}

		private void OnHome()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.BattleResultModule) as BattleResultModule;
			if (module != null)
			{
				module.OnHome();
			}
			AudioManager.Instance.PlayClick ();
		}

	
	}
}

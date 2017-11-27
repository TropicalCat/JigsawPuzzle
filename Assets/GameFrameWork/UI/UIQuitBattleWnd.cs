using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UIQuitBattleWnd : UIWindow 
	{
		[SerializeField]
		private Button m_btnCofirm;

		public GameObject[] m_levelItems;

		private int[] m_randomlevels = {0,0,0,0};

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);

			if (m_btnCofirm != null)
			{
				m_btnCofirm.onClick.AddListener(OnConfirm);
			}

			initRandomLevel ();

			//ads
			GFW.AdsManager.Instance.ShowBannerABS (70, 1300);
		}

		void initRandomLevel()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.QuitBattleModule) as QuitBattleModule;
			if (module != null) 
			{
				for(int i = 0; i < m_levelItems.Length; i++)
				{
					int level = module.RandomLevel();
					Image image = m_levelItems [i].GetComponent<Image> ();
					image.sprite = Resources.Load("Texture/Piece/illustration/Illustration"+level, typeof(Sprite)) as Sprite;

					Button btnLevel = m_levelItems [i].GetComponent<Button> ();
					btnLevel.name = "" + level;
					btnLevel.onClick.AddListener( 
						delegate() 
						{  
							this.OnLevelClick(btnLevel.gameObject);
						});  
				}
			}
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnCofirm != null)
			{
				m_btnCofirm.onClick.RemoveAllListeners();
			}

			base.OnClose (arg);

			//ads
			GFW.AdsManager.Instance.RemoveBanner ();
		}


		public void OnCancel()
		{
		}

		public void OnConfirm()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.QuitBattleModule) as QuitBattleModule;
			if (module != null)
			{
				module.OnQuitBattle();
			}
			AudioManager.Instance.PlayClick ();
		}


		private void OnLevelClick(GameObject gameObject)
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.QuitBattleModule) as QuitBattleModule;
			if (module != null)
			{
				module.OnSelectLevel(int.Parse(gameObject.name));
			}
			AudioManager.Instance.PlayClick ();
		}



	}
}


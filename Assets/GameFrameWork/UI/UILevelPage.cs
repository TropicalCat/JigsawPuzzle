using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UILevelPage : UIPage
	{
		public GameObject[] levelItems;

		[SerializeField]
		private Button m_btnBack;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
			if (m_btnBack != null)
			{
				m_btnBack.onClick.AddListener(OnBack);
			}
			initLevel ();
		}

		private void initLevel()
		{
			for(int i = 0; i < levelItems.Length; i++)
			{
				int level = i + 1;
				Image image = levelItems [i].GetComponent<Image> ();
				image.sprite = Resources.Load("Texture/Piece/illustration/Illustration"+level, typeof(Sprite)) as Sprite;

				Button btnLevel = levelItems [i].GetComponent<Button> ();
				btnLevel.name = "" + level;
				btnLevel.onClick.AddListener( 
					delegate() 
					{  
						this.OnLevelClick(btnLevel.gameObject);
					});  
			}
		}

		protected override void OnClose(object arg = null)
		{
			for(int i = 0; i < levelItems.Length; i++)
			{
				Button btnLevel = levelItems [i].GetComponent<Button> ();
				btnLevel.onClick.RemoveAllListeners ();
			}

			if (m_btnBack != null)
			{
				m_btnBack.onClick.RemoveAllListeners();
			}
			base.OnClose (arg);
		}

		private void OnLevelClick(GameObject gameObject)
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.LevelModule) as LevelModule;
			if (module != null)
			{
				module.OnSelectLevel(int.Parse(gameObject.name));
			}
			AudioManager.Instance.PlayClick ();
		}

		public void OnBack()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.LevelModule) as LevelModule;
			if (module != null)
			{
				module.OnBack();
			}
			AudioManager.Instance.PlayClick ();
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UIBattlePage : UIPage 
	{
		[SerializeField]
		private Button m_btnArtist;

		[SerializeField]
		private Button m_btnQuit;

		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
			initPiece ();

			if (m_btnArtist != null)
			{
				m_btnArtist.onClick.AddListener(OnArtist);
			}

			if (m_btnQuit != null) 
			{
				m_btnQuit.onClick.AddListener (OnQuitBattle);
			}

			showArtist (false);
		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnArtist != null)
			{
				m_btnArtist.onClick.RemoveAllListeners();
			}
			if (m_btnQuit != null)
			{
				m_btnQuit.onClick.RemoveAllListeners();
			}

			base.OnClose (arg);
			//销毁掉窗口
			Destroy (gameObject);
		}
			
		void initPiece()
		{
			string pth = PieceManager.Instance.GetCurIllustration ();

			Sprite pieceImage = Resources.Load(pth, typeof(Sprite)) as Sprite;

			Image image = gameObject.transform.Find ("LeftDown").Find ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			image = gameObject.transform.Find ("LeftUp").Find ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			image = gameObject.transform.Find ("RightDown").Find ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			image = gameObject.transform.Find ("RightUp").Find ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			image = gameObject.transform.Find ("PieceZone").GetComponent<Image> ();
			image.sprite = pieceImage;

		}
			
		private void OnArtist()
		{
			GameObject obj = gameObject.transform.Find ("PieceZone").gameObject;
			showArtist (!obj.activeSelf);
		}
			
		private void showArtist(bool bShow)
		{
			GameObject objPieceZone = gameObject.transform.Find ("PieceZone").gameObject;
			objPieceZone.SetActive (bShow);

			if (m_btnArtist != null) 
			{
				if (!bShow) 
				{
					Image image = m_btnArtist.GetComponent<Image> ();
					image.sprite = Resources.Load("Texture/UI/ArtistOff", typeof(Sprite)) as Sprite;
				}
				else 
				{
					Image image = m_btnArtist.GetComponent<Image> ();
					image.sprite = Resources.Load("Texture/UI/ArtistShow", typeof(Sprite)) as Sprite;
				}
			}
		}

		private void OnQuitBattle()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.BattleModule) as BattleModule;
			if (module != null)
			{
				module.OnQuitBattle();
			}	
		}


	}
}

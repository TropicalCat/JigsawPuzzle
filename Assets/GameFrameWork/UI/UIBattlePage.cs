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


		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
			initPiece ();

			if (m_btnArtist != null)
			{
				m_btnArtist.onClick.AddListener(OnArtist);
			}

		}

		protected override void OnClose(object arg = null)
		{
			if (m_btnArtist != null)
			{
				m_btnArtist.onClick.RemoveAllListeners();
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
			obj.SetActive (!obj.activeSelf);


			
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UIBattlePage : UIPage 
	{
		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
			initPiece ();
		}

		protected override void OnClose(object arg = null)
		{
			base.OnClose (arg);
			//销毁掉窗口
			Destroy (gameObject);
		}


		void initPiece()
		{
			string pth = PieceManager.Instance.GetCurIllustration ();

			Image image = gameObject.transform.FindChild ("LeftDown").FindChild ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			 image = gameObject.transform.FindChild ("LeftUp").FindChild ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			 image = gameObject.transform.FindChild ("RightDown").FindChild ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;

			 image = gameObject.transform.FindChild ("RightUp").FindChild ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;


		}
	}
}

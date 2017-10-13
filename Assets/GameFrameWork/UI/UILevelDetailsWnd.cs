using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UILevelDetailsWnd : UIWindow 
	{
		[SerializeField]
		private Button m_btnStart;

		[SerializeField]
		private Button m_btnIncrease;

		[SerializeField]
		private Button m_btnReduce;

		[SerializeField]
		private Button m_btnNormal;

		[SerializeField]
		private Button m_btnRevolve;


		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
			if (m_btnStart != null)
			{
				m_btnStart.onClick.AddListener(OnStart);
			}
			if (m_btnIncrease != null)
			{
				m_btnIncrease.onClick.AddListener(OnIncreasePiece);
			}
			if (m_btnReduce != null)
			{
				m_btnReduce.onClick.AddListener(OnReducePiece);
			}
			if (m_btnNormal != null)
			{
				m_btnNormal.onClick.AddListener(OnNormal);
			}
			if (m_btnRevolve != null)
			{
				m_btnRevolve.onClick.AddListener(OnRevolve);
			}

			initPiece ();
			pieceCount ();
			normalIcon ();
			revolveIcon ();
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
			if (m_btnIncrease != null)
			{
				m_btnIncrease.onClick.RemoveAllListeners();
			}
			if (m_btnReduce != null)
			{
				m_btnReduce.onClick.RemoveAllListeners();
			}
			if (m_btnNormal != null)
			{
				m_btnNormal.onClick.RemoveAllListeners();
			}
			if (m_btnRevolve != null)
			{
				m_btnRevolve.onClick.RemoveAllListeners();
			}
			base.OnClose (arg);

//			UIManager.Instance.CloseWindow (this);
//			//销毁掉窗口
//			Destroy (gameObject);
		}

		private void OnStart()
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.LevelDetailsModule) as LevelDetailsModule;
			if (module != null)
			{
				module.OnStartBattle (0,0);
			}	
		}

		private void OnIncreasePiece()
		{
			PieceManager.Instance.IncreasePiece ();
			pieceCount ();
		}

		private void OnReducePiece()
		{
			PieceManager.Instance.ReducePiece ();
			pieceCount ();
		}

		private void pieceCount()
		{
			string pth = PieceManager.Instance.GetCurPieceCount ();
			Image image = gameObject.transform.Find ("Piece").GetComponent<Image> ();
			image.sprite = Resources.Load(pth, typeof(Sprite)) as Sprite;
		}


		private void OnNormal()
		{
			PieceManager.Instance.Difficulty = false;
			normalIcon ();
		}

		private void normalIcon()
		{
			if (m_btnNormal == null) 
			{
				return;
			}
			if (PieceManager.Instance.Difficulty) 
			{
				Image image = m_btnNormal.GetComponent<Image> ();
				image.sprite = Resources.Load("Texture/UI/NormalSelect", typeof(Sprite)) as Sprite;
			} 
			else
			{
				Image image = m_btnNormal.GetComponent<Image> ();
				image.sprite = Resources.Load("Texture/UI/Normal", typeof(Sprite)) as Sprite;
			}
		}

		private void OnRevolve()
		{
			PieceManager.Instance.Revolve = false;
			revolveIcon ();
		}

		private void revolveIcon()
		{
			if (m_btnRevolve == null) 
			{
				return;
			}
			if (!PieceManager.Instance.Revolve) 
			{
				Image image = m_btnRevolve.GetComponent<Image> ();
				image.sprite = Resources.Load ("Texture/UI/Revolve", typeof(Sprite)) as Sprite;
			} 
			else 
			{
				Image image = m_btnRevolve.GetComponent<Image> ();
				image.sprite = Resources.Load("Texture/UI/RevolveSelect", typeof(Sprite)) as Sprite;
			}
		}

	}
}
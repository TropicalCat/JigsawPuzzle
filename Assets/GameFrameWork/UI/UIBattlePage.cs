﻿using System.Collections;
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

		Image m_image_H;
		Image m_image_h;
		Image m_image_M;
		Image m_image_m;
		Image m_image_S;
		Image m_image_s;



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

			m_image_H = gameObject.transform.Find ("Time/H").GetComponent<Image>();
			m_image_h = gameObject.transform.Find ("Time/h").GetComponent<Image>();
			m_image_M = gameObject.transform.Find ("Time/M").GetComponent<Image>();
			m_image_m = gameObject.transform.Find ("Time/m").GetComponent<Image>();
			m_image_S = gameObject.transform.Find ("Time/S").GetComponent<Image>();
			m_image_s = gameObject.transform.Find ("Time/s").GetComponent<Image>();


			gameObject.transform.Find ("EffectStar").GetComponent<Animator> ().Play ("Stop");

			//ads
			GFW.AdsManager.Instance.RemoveBanner ();
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
			//Destroy (gameObject);
		}
			
		void initPiece()
		{
			string pth = PieceManager.Instance.GetCurIllustration ();

			Sprite pieceImage = Resources.Load(pth, typeof(Sprite)) as Sprite;

			Image image = gameObject.transform.Find ("PieceZone").GetComponent<Image> ();
			image.sprite = pieceImage;

			for (int i = 0; i < PieceManager.Instance.PieceCount; i++) 
			{
				image = gameObject.transform.Find((i+1).ToString()).Find("Piece").GetComponent<Image>();
				image.sprite = pieceImage;
			}
		}

		// Update is called once per frame
		void Update () 
		{
			var module = ModuleManager.Instance.GetModule(ModuleDef.BattleModule) as BattleModule;
			if (module != null)
			{
				module.CalculateTime();

				int hh = module.GetHH ();
				m_image_H.sprite = AssetManager.Instance.GetNumberSprite ("Number"+ (hh/10));
				m_image_h.sprite = AssetManager.Instance.GetNumberSprite ("Number"+ (hh%10));
				int mm = module.GetMM ();
				m_image_M.sprite = AssetManager.Instance.GetNumberSprite ("Number"+ (mm/10));
				m_image_m.sprite = AssetManager.Instance.GetNumberSprite ("Number"+ (mm%10));
				int ss = module.GetSS ();
				m_image_S.sprite = AssetManager.Instance.GetNumberSprite ("Number"+ (ss/10));
				m_image_s.sprite = AssetManager.Instance.GetNumberSprite ("Number"+ (ss%10));
			}
		}
			
		private void OnArtist()
		{
			GameObject obj = gameObject.transform.Find ("PieceZone").gameObject;
			showArtist (!obj.activeSelf);
			AudioManager.Instance.PlayClick ();
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
			AudioManager.Instance.PlayClick ();
		}


	}
}

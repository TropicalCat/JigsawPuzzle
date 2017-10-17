using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{

	public class AudioManager :  ServiceModule<AudioManager> 
	{
		AudioSource m_BGAudio;		//背景音乐
		AudioSource m_effectAudio;	//普通音效

		AudioClip m_clickClip;	//按钮点击
		AudioClip m_upClip;		//piece抬起
		AudioClip m_downClip;	//piece放下
		AudioClip m_goClip;		//游戏开始

		public AudioManager()
		{
		}

		public void Init()
		{
			m_BGAudio = GameObject.Find ("Music").GetComponent<AudioSource>();
			m_BGAudio.loop = true;
			//m_BGAudio.Stop ();
			m_effectAudio = GameObject.Find ("Sound").GetComponent<AudioSource>();


			m_clickClip = Resources.Load("Audio/Click") as AudioClip;
			m_upClip = Resources.Load("Audio/Up") as AudioClip;
			m_downClip = Resources.Load("Audio/Down") as AudioClip;
			m_goClip = Resources.Load("Audio/Go") as AudioClip;
		}

		public void Destory()
		{
		}

		public void Clear()
		{
		}

		/// <summary>
		/// Plaies the background music.
		/// </summary>
		public void PlayBGMusic()
		{
			m_BGAudio.Play ();
		}

		/// <summary>
		/// Stops the background music.
		/// </summary>
		public void StopBGMusic()
		{
			m_BGAudio.Stop ();
		}

		/// <summary>
		/// 按钮click
		/// </summary>
		public void PlayClick()
		{
			
			m_effectAudio.clip = m_clickClip;
			m_effectAudio.Play ();
		}

		//piece抬起
		public void PieceUp()
		{
			m_effectAudio.clip = m_upClip;
			m_effectAudio.Play ();
		}

		//piece放下
		public void PieceDown()
		{
			m_effectAudio.clip = m_downClip;
			m_effectAudio.Play ();
		}

		//游戏开始
		public void GameGo()
		{
			m_effectAudio.clip = m_goClip;
			m_effectAudio.Play ();
		}



	}
}

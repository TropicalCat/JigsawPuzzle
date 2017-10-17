using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{

	public class AudioManager :  ServiceModule<AudioManager> 
	{
		AudioSource m_BGAudio;		//背景音乐
		AudioSource m_EffectAudio;	//普通音效

		public AudioManager()
		{
		}

		public void Init()
		{
			m_BGAudio = GameObject.Find ("Music").GetComponent<AudioSource>();
			m_BGAudio.loop = true;
			//m_BGAudio.Stop ();
			m_EffectAudio = GameObject.Find ("Sound").GetComponent<AudioSource>();
		}

		public void Destory()
		{
		}

		public void Clear()
		{
		}

		public void PlayBtnClick()
		{
			AudioClip clip = Resources.Load("Audio/Click") as AudioClip;
			m_EffectAudio.clip = clip;
			m_EffectAudio.Play ();
		}



	}
}

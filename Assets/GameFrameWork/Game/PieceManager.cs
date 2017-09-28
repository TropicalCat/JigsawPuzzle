﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class PieceManager : ServiceModule<PieceManager>
	{

		private int CurLevel;		//当前关卡	
		private int CurDifficulty;	//当前难度



		public PieceManager()
		{
		}

		public void Init()
		{
			CurLevel=0;		//当前关卡	
			CurDifficulty=0;
		}

		public void Destory()
		{
		}

		public void Clear()
		{
			CurLevel=0;		//当前关卡	
			CurDifficulty=0;
		}
			
		public void SetLevel(int level)
		{
			CurLevel = level;

		}

		public void SetDifficulty(int difficulty)
		{
			CurDifficulty = difficulty;
		}

		public string GetCurIllustration()
		{
			return "Texture/Piece/illustration/Illustration" + CurLevel;
		}





	}
}



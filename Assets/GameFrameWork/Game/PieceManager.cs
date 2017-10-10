using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class PieceManager : ServiceModule<PieceManager>
	{

		private int CurLevel;		//当前关卡	
		private int CurDifficulty;	//当前难度
		private int CurPieceCount;	//当前碎片数量


		private int DonePieceCount;	//完成


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
			//CurPieceCount = 4;
		}

		public void SetDifficulty(int difficulty)
		{
			CurDifficulty = difficulty;
		}

		public int PieceCount
		{
			get{ return CurPieceCount;}
			set{ CurPieceCount = value;}
		}

		public string GetCurIllustration()
		{
			return "Texture/Piece/illustration/Illustration" + CurLevel;
		}

		public void DonePiece()
		{
			DonePieceCount++;

			if(DonePieceCount >= CurPieceCount)
			{
				//胜利
				ModuleManager.Instance.ShowModule(ModuleDef.ResultModule, null);
			}	
		}

	
		public void ClearPiece()
		{
			DonePieceCount = 0;
		}





	}
}



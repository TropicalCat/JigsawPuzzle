using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class PieceManager : ServiceModule<PieceManager>
	{

		private int CurLevel;		//当前关卡	
		private bool IsNormal;	//当前难度
		private bool IsRevolve;
		private int CurPieceCount;	//当前碎片数量


		private int DonePieceCount;	//完成


		public PieceManager()
		{
		}

		public void Init()
		{
			CurLevel=0;		//当前关卡	
			IsNormal=false;
			IsRevolve = false;
			CurPieceCount = 4;
			DonePieceCount = 0;
		}

		public void Destory()
		{
		}

		public void Clear()
		{
			CurLevel=0;		//当前关卡	
			IsNormal=false;
			IsRevolve = false;
			CurPieceCount = 4;
			DonePieceCount = 0;
		}
			
		public void SetLevel(int level)
		{
			CurLevel = level;
		}

		public int GetCurLevel()
		{
			return CurLevel;
		}

		public bool Difficulty
		{
			get{ return IsNormal;}
			set{ IsNormal = !IsNormal;}
		}

		public bool Revolve
		{
			get{ return IsRevolve;}
			set{ IsRevolve = !IsRevolve;}
		}
			
		public int PieceCount
		{
			get{ return CurPieceCount;}
			set{ CurPieceCount = value;}
		}

		public void IncreasePiece()
		{
			switch (CurPieceCount) 
			{
			case 4:
				PieceCount = 9;
				break;
			case 9:
				PieceCount = 16;
				break;
			case 16:
				PieceCount = 25;
				break;
			case 25:
				PieceCount = 36;
				break;
			default:
				break;
			}
		}

		public void ReducePiece()
		{
			switch (CurPieceCount) 
			{
			case 36:
				PieceCount = 25;
				break;
			case 25:
				PieceCount = 16;
				break;
			case 16:
				PieceCount = 9;
				break;
			case 9:
				PieceCount = 4;
				break;
			default:
				break;
			}
		}

		public string GetCurPieceCount()
		{
			return "Texture/UI/Piece/Piece" + CurPieceCount;
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



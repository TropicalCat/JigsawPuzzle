using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class PieceManager : ServiceModule<PieceManager>
	{
		private int m_curLevel;		//当前关卡	
		private bool m_isNormal;	//是否困难模式
		private bool m_isRevolve;	//是否旋转模式
		private int m_curPieceCount;	//当前碎片总数量
		private int m_donePieceCount;	//复位的碎片数量

		public PieceManager()
		{
		}

		public void Init()
		{
			m_curLevel=0;		//当前关卡	
			m_isNormal = true;
			m_isRevolve = false;
			m_curPieceCount = 4;
			m_donePieceCount = 0;
		}

		public void Destory()
		{
		}

		public void Clear()
		{
			m_curLevel=0;		//当前关卡	
			m_isNormal = true;
			m_isRevolve = false;
			m_curPieceCount = 4;
			m_donePieceCount = 0;
		}
			
		public void SetLevel(int level)
		{
			m_curLevel = level;
		}

		public int GetCurLevel()
		{
			return m_curLevel;
		}

		public bool Difficulty
		{
			get{ return m_isNormal;}
			set{ m_isRevolve = false; m_isNormal = true; }
		}

		public bool Revolve
		{
			get{ return m_isRevolve;}
			set{ m_isRevolve = true; m_isNormal = false; }
		}
			
		public int PieceCount
		{
			get{ return m_curPieceCount;}
			set{ m_curPieceCount = value;}
		}

		public void IncreasePiece()
		{
			switch (m_curPieceCount) 
			{
			case 4:
				m_curPieceCount = 9;
				break;
			case 9:
				m_curPieceCount = 16;
				break;
			case 16:
				m_curPieceCount = 25;
				break;
//			case 25:
//				m_curPieceCount = 36;
//				break;
			default:
				break;
			}
		}

		public void ReducePiece()
		{
			switch (m_curPieceCount) 
			{
//			case 36:
//				m_curPieceCount = 25;
//				break;
			case 25:
				m_curPieceCount = 16;
				break;
			case 16:
				m_curPieceCount = 9;
				break;
			case 9:
				m_curPieceCount = 4;
				break;
			default:
				break;
			}
		}

		public string GetCurPieceCount()
		{
			return "Texture/UI/Piece/Piece" + m_curPieceCount;
		}

		public string GetCurIllustration()
		{
			return "Texture/Piece/illustration/Illustration" + m_curLevel;
		}

		public void DonePiece()
		{
			m_donePieceCount++;
			if(m_donePieceCount >= m_curPieceCount)
			{
				//胜利
				ModuleManager.Instance.ShowModule(ModuleDef.BattleResultModule, null);
				AudioManager.Instance.GameSuccess ();
			}	
		}
			
		public void ClearPiece()
		{
			m_donePieceCount = 0;
		}





	}
}



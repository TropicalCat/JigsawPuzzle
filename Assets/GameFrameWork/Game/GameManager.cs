using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class GameManager : ServiceModule<GameManager>
	{
		int m_maxLevel = 10;	//最大关卡
		public GameManager()
		{
		}

		public void Init()
		{
		}

		public void Destory()
		{
		}

		public void Clear()
		{
		}

		//开始拼图
		public void StartBattle()
		{
			ModuleManager.Instance.ShowModule(ModuleDef.BattleModule);
		}

		//重新开始拼图
		public void RestartBattle()
		{
			PieceManager.Instance.ClearPiece ();
			ModuleManager.Instance.ShowModule(ModuleDef.BattleModule);
		}

		//完成拼图
		public void EndBattle()
		{
		}

		//未完成退出拼图
		public void QuitBattle()
		{
		}

		//下一个关卡
		public void StartNextBattle()
		{
			if (PieceManager.Instance.GetCurLevel () < m_maxLevel) 
			{
				PieceManager.Instance.SetLevel (PieceManager.Instance.GetCurLevel () + 1);
				ModuleManager.Instance.ShowModule (ModuleDef.BattleModule);
			} 
			else
			{
				// 新关卡未开放
			}
		}

		public int GetMaxLevel()
		{
			return m_maxLevel;
		}

	}
}
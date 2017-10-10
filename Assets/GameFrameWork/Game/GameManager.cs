using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{
	public class GameManager : ServiceModule<GameManager>
	{
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

		//
		public void StartNextBattle()
		{
		}

	}
}
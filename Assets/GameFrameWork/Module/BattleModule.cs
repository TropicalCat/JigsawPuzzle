using UnityEngine;
using System.Collections;
using GE;


namespace GFW
{
	public class BattleModule : BusinessModule
	{
		int m_hh = 60 * 60;
		int m_mm = 60;
		float m_BattleLastTime = 0f;

		int m_LastHH = 0;
		int m_LastMM = 0;
		int m_LastSS = 0;




		protected override void Show(object arg)
		{
			base.Show (arg);
			switch (PieceManager.Instance.PieceCount) 
			{
			case 4:
				UIManager.Instance.OpenPage(UIDef.UIBattle4Master);
				break;
			case 9:
				UIManager.Instance.OpenPage(UIDef.UIBattle9Master);
				break;
			case 16:
				UIManager.Instance.OpenPage(UIDef.UIBattle9Master);
				break;
			case 25:
				UIManager.Instance.OpenPage(UIDef.UIBattle9Master);
				break;
			default:
				break;
			}

			m_BattleLastTime = 0;
			m_LastHH = 0;
			m_LastMM = 0;
			m_LastSS = 0;
		}

		public void OnQuitBattle()
		{
			ModuleManager.Instance.ShowModule(ModuleDef.QuitBattleModule);
		}


		public void CalculateTime()
		{
			m_BattleLastTime += Time.deltaTime;
			int battleTime = (int)m_BattleLastTime;

			m_LastHH = battleTime / m_hh;
			m_LastMM = battleTime % m_hh / m_mm;
			m_LastSS = battleTime % m_hh % m_mm;
		}

		public int GetHH()
		{
			return m_LastHH;
		}

		public int GetMM()
		{
			return m_LastMM;
		}

		public int GetSS()
		{
			return m_LastSS;
		}





	}
	
}



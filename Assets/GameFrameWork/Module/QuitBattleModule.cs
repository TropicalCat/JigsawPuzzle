using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;


namespace GFW
{
	public class QuitBattleModule : BusinessModule 
	{
		private List<int> m_otherLevels = new List<int>();//关卡池子，用于随机关卡

		protected override void Show(object arg)
		{
			base.Show (arg);

			initOtherLevels ();
		
			UIManager.Instance.OpenWindow (UIDef.UIQuitBattle);
			if (null != arg) 
			{
				//string s = arg.ToString();
			}
		}
			
		public void OnQuitBattle()
		{
			UIManager.Instance.EnterMainPage ();	
		}

		void initOtherLevels()
		{
			m_otherLevels.Clear();
			int maxLevel = GameManager.Instance.GetMaxLevel ();
			int curLevel = PieceManager.Instance.GetCurLevel ();
			for (int i = 0; i < maxLevel; i++) 
			{
				if (curLevel != i + 1) 
				{
					m_otherLevels.Add (i+1);
				}
			}
		}

		public int RandomLevel()
		{
			int index = UnityEngine.Random.Range (0, m_otherLevels.Count - 1);
			int randomLevel = m_otherLevels [index];
			m_otherLevels.Remove (index);
			return randomLevel;
		}
			
	}

}


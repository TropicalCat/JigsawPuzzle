using UnityEngine;
using System.Collections;
using GE;


namespace GFW
{

	public class LevelDetailsModule : BusinessModule
	{
		
		protected override void Show(object arg)
		{
			base.Show (arg);
			UIManager.Instance.OpenWindow(UIDef.UILevelDetails);
		}

		public void OnStartBattle()
		{
			ModuleManager.Instance.ShowModule (ModuleDef.LoadingModule);
		}
			
		public void OnIncreasePiece()
		{
			PieceManager.Instance.IncreasePiece ();
		}

		public void OnReducePiece()
		{
			PieceManager.Instance.ReducePiece ();
		}

		public void OnNormal()
		{
			PieceManager.Instance.Difficulty = false;
		}

		public void OnRevolve()
		{
			PieceManager.Instance.Revolve = false;
		}
	
	}
}


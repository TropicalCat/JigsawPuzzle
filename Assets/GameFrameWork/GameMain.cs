using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;
using GFW;
using UnityEngine.Analytics;
using UnityEngine.Advertisements;

public class GameMain : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		Debuger.EnableLog = false;

		InitServices ();
		InitBusiness ();

		ModuleManager.Instance.ShowModule (ModuleDef.HomeModule);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	private void InitServices()
	{
		ModuleManager.Instance.Init ("GFW");
		AssetManager.Instance.Init ();
		UIManager.Instance.Init ("Prefab/UI/");
		GameManager.Instance.Init ();
		PieceManager.Instance.Init ();
		AudioManager.Instance.Init ();
		AdsManager.Instance.Init ();
	}

	private void InitBusiness()
	{
		ModuleManager.Instance.CreateModule (ModuleDef.HomeModule);
		ModuleManager.Instance.CreateModule (ModuleDef.LevelModule);
		ModuleManager.Instance.CreateModule (ModuleDef.LevelDetailsModule);
		ModuleManager.Instance.CreateModule (ModuleDef.LoadingModule);
		ModuleManager.Instance.CreateModule (ModuleDef.BattleModule);
		ModuleManager.Instance.CreateModule (ModuleDef.QuitBattleModule);
		ModuleManager.Instance.CreateModule (ModuleDef.BattleResultModule);
	}
}

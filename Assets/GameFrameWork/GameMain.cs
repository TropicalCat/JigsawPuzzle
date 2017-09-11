using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

public class GameMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debuger.EnableLog = true;
		ModuleManager.Instance.CreateModule ("login");
		ModuleManager.Instance.ShowModule ("login");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

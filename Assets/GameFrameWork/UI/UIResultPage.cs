using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GE;

namespace GFW
{

	public class UIResultPage : UIPage
	{
		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);
		}

		protected override void OnClose(object arg = null)
		{
			base.OnClose (arg);
			//销毁掉窗口
			Destroy (gameObject);
		}

	
	}
}

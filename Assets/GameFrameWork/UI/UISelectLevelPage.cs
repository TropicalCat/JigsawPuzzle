using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GE;


namespace GFW
{
	public class UISelectLevelPage : UIPage
	{
		public GameObject[] levelItems;
		protected override void OnOpen(object arg = null)
		{
			base.OnOpen (arg);

			for(int i = 0; i < levelItems.Length; i++)
			{
				Image image = levelItems [i].GetComponent<Image> ();
				image.sprite = Resources.Load("Texture/Piece/illustration/Illustration"+(i+1), typeof(Sprite)) as Sprite;

				Button btn = levelItems [i].GetComponent<Button> ();


				btn.onClick.AddListener( 
					delegate() 
					{  
						this.OnClick(levelItems [i]);
					});  
			}

		}

		private void OnClick(GameObject obj)
		{

			//int 
			string name = obj.name;
	
		}




	}
}


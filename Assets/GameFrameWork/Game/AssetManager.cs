using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GE;

namespace GFW
{
	public class AssetManager :  ServiceModule<AssetManager>
	{
		private Dictionary<string, Sprite> m_DicSprite;

		public AssetManager()
		{
			m_DicSprite = new Dictionary<string, Sprite> ();
		}

		public void Init()
		{
			AddSprite ("Number0");
			AddSprite ("Number1");
			AddSprite ("Number2");
			AddSprite ("Number3");
			AddSprite ("Number4");
			AddSprite ("Number5");
			AddSprite ("Number6");
			AddSprite ("Number7");
			AddSprite ("Number8");
			AddSprite ("Number9");
		}

		public void Destory()
		{
		}

		public void Clear()
		{
		}

		private void AddSprite(string name)
		{
			Sprite sprite = Resources.Load("Texture/UI/Number/"+name, typeof(Sprite)) as Sprite;
			m_DicSprite.Add (name, sprite);
		}

		public Sprite GetNumberSprite(string name)
		{
			Sprite sprite;
			m_DicSprite.TryGetValue (name, out sprite);
			return sprite;
		}



	}


}

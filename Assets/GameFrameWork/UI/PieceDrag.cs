using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using GE;
using GFW;


//给空间添加监听事件要实现的一些接口
public class PieceDrag :MonoBehaviour, 
						IPointerDownHandler, 
					    IDragHandler, 
						IPointerUpHandler,
						IEndDragHandler,
						IPointerEnterHandler,
						IPointerExitHandler
{
	public RectTransform canvas;          //得到canvas的ugui坐标
	private RectTransform imgRect;        //得到图片的ugui坐标
	Vector2 offset = new Vector3();    //用来得到鼠标和图片的差值
	Vector3 imgReduceScale = new Vector3(0.3f, 0.3f, 1);   //设置图片缩放
	Vector3 imgNormalScale = new Vector3(1, 1, 1);   //正常大小

	bool bDown;

	bool bScaleup;//放大flag
	bool bScaledown;//渐渐缩小
	Vector2 originPos;
	bool bAutoMove;


	int mAngle;

	Vector2 targetPos = new Vector3();
	bool targetOKay  = false;

	// Use this for initialization
	void Start () 
	{
		imgRect = GetComponent<RectTransform>();
		Canvas uiRoot = GameObject.Find("UIRoot").GetComponent<Canvas>();
		if (null != uiRoot) 
		{
			canvas = uiRoot.transform as RectTransform;
		}

		targetPos = imgRect.anchoredPosition;

		targetOKay = false;
		imgRect.anchoredPosition = new Vector2 (RandomPosX(targetPos.x),   UnityEngine.Random.Range(-600,-800));
		imgRect.localScale = imgReduceScale;   //缩小图片

		bScaleup = false;


		mAngle = 0;
		if (PieceManager.Instance.Revolve) 
		{
			int rand = UnityEngine.Random.Range (1, 3);
			mAngle = rand * 90;
			transform.Rotate (new Vector3(0f, 0f, mAngle));
		}


	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (bDown) 
//		{
//
//			Vector2 uguiPos = new Vector2();
//			bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas, Input.mousePosition, canvas.GetComponent<Canvas> ().worldCamera, out uguiPos);
//			if(isRect)
//			{
//				imgRect.anchoredPosition = offset + uguiPos;
//			}
//		}

	
		//渐渐变大
		if (bScaleup) 
		{
			imgRect.localScale = new Vector3(imgRect.localScale.x+0.1f, imgRect.localScale.y+0.1f, 1f);   //放大图片
			if(imgRect.localScale.x >= 1.0f)
				bScaleup = false;
		}
		//渐渐变小
		if (bScaledown) 
		{
			imgRect.localScale = new Vector3(imgRect.localScale.x-0.1f, imgRect.localScale.y-0.1f, 1f);   //放大图片
			if(imgRect.localScale.x <= 0.3f)
				bScaledown = false;
		}

		//自动移动
		if (bAutoMove) 
		{
			Vector2 dir = (originPos - imgRect.anchoredPosition).normalized;
			Vector2 nextPos = imgRect.anchoredPosition + dir * 2000f * Time.deltaTime;
			if (Vector2.Distance (originPos, nextPos) <= 100f) {
				imgRect.anchoredPosition = originPos;
				bAutoMove = false;
			} else {
				imgRect.anchoredPosition = nextPos;
			}
		}
	}

	//当鼠标按下时调用 接口对应  IPointerDownHandler
	public void OnPointerDown(PointerEventData eventData)
	{

		if (targetOKay) 
		{
			//缩放复位	
			if (mAngle > 0) 
			{
				mAngle -= 90;
				transform.Rotate (new Vector3(0f, 0f, -90));
			}
			return;
		}

		//imgRect.localScale = imgNormalScale;   //放大图片
		bScaleup = true;
		Vector2 mouseDown = eventData.position;    //记录鼠标按下时的屏幕坐标
		Vector2 mouseUguiPos = new Vector2();   //定义一个接收返回的ugui坐标
		//RectTransformUtility.ScreenPointToLocalPointInRectangle()：把屏幕坐标转化成ugui坐标
		//canvas：坐标要转换到哪一个物体上，这里img父类是Canvas，我们就用Canvas
		//eventData.enterEventCamera：这个事件是由哪个摄像机执行的
		//out mouseUguiPos：返回转换后的ugui坐标
		//isRect：方法返回一个bool值，判断鼠标按下的点是否在要转换的物体上
		bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mouseDown, eventData.enterEventCamera, out mouseUguiPos);
		if (isRect)   //如果在
		{
			//计算图片中心和鼠标点的差值
			offset = imgRect.anchoredPosition - mouseUguiPos;

			imgRect.transform.SetSiblingIndex(100);
		}
		bDown = true;

		AudioManager.Instance.PieceUp ();
	}

	//当鼠标拖动时调用   对应接口 IDragHandler
	public void OnDrag(PointerEventData eventData)
	{
		if (targetOKay)
			return;
		Vector2 mouseDrag = eventData.position;   //当鼠标拖动时的屏幕坐标
		Vector2 uguiPos = new Vector2();   //用来接收转换后的拖动坐标
		//和上面类似
		bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, mouseDrag, eventData.enterEventCamera, out uguiPos);
		if (isRect)
		{
			//设置图片的ugui坐标与鼠标的ugui坐标保持不变
			imgRect.anchoredPosition = offset + uguiPos;
		}
	}

	//当鼠标抬起时调用  对应接口  IPointerUpHandler
	public void OnPointerUp(PointerEventData eventData)
	{
		if (targetOKay)
			return;




		offset = Vector2.zero;
		bDown = false;
		//imgRect.localScale = imgNormalScale;   //回复图片

		Vector2 curPos = imgRect.anchoredPosition;
		//curPos = (targetPos - curPos);

		Vector2 size = imgRect.sizeDelta;

		float mag = size.sqrMagnitude;
		//size.sqrMagnitude


		float dis = Vector2.Distance (targetPos , curPos);

		if (  dis <= 100f) //Math.Abs (curPos.x) <= 32f || Math.Abs (curPos.y) <= 32f) 
		{
			imgRect.anchoredPosition = targetPos;
			targetOKay = true;

			GameObject effObj = gameObject.transform.parent.Find ("EffectStar").gameObject;
			effObj.transform.localPosition = imgRect.anchoredPosition3D;
			Animator ani = effObj.GetComponent<Animator>();
			ani.SetTrigger("again");


			StartCoroutine (DonePiece ());
		} 
		else
		{
			if (imgRect.anchoredPosition.y >= -600) 
			{
				originPos = new Vector2(RandomPosX(targetPos.x),   UnityEngine.Random.Range(-600,-800));
				bAutoMove = true;




				//imgRect.anchoredPosition = new Vector2(RandomPosX(targetPos.x),   UnityEngine.Random.Range(-600,-800));
			}
			//imgRect.localScale = imgReduceScale;
			bScaledown = true;
		}

		AudioManager.Instance.PieceDown ();
	}

	//当鼠标结束拖动时调用   对应接口  IEndDragHandler
	public void OnEndDrag(PointerEventData eventData)
	{
		if (targetOKay)
			return;
		offset = Vector2.zero;
//
//		Vector2 curPos = imgRect.anchoredPosition;
//		curPos = (targetPos - curPos);
//		if (Math.Abs (curPos.x) <= 32f || Math.Abs (curPos.y) <= 32f) 
//		{
//			imgRect.anchoredPosition = targetPos;
//			targetOKay = true;
//
//			StartCoroutine (DonePiece ());
//		} 
//		else
//		{
//			imgRect.localScale = imgReduceScale;
//		}

	}

	//当鼠标进入图片时调用   对应接口   IPointerEnterHandler
	public void OnPointerEnter(PointerEventData eventData)
	{
		//imgRect.localScale = imgReduceScale;   //缩小图片
	}

	//当鼠标退出图片时调用   对应接口   IPointerExitHandler
	public void OnPointerExit(PointerEventData eventData)
	{
		//imgRect.localScale = imgNormalScale;   //回复图片
	}


	IEnumerator DonePiece()
	{
		yield return new WaitForSeconds (0.5f);
		PieceManager.Instance.DonePiece ();
	}

	float RandomPosX(float posX)
	{
		if (posX > 0) {
			return posX + UnityEngine.Random.Range (-300, 0);
		} else if (posX < 0) {
			return posX + UnityEngine.Random.Range (0, 300);
		} else  {
			return posX + UnityEngine.Random.Range (-300, 300);
		}
	}







}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPoint : MonoBehaviour 
{
	public WindowAnimation WindowAnimation
	{
		get {return windowAnimation;}
	}
	void Start()
	{
		windowAnimation = transform.parent.GetComponentInChildren<WindowAnimation>();
	}
	private WindowAnimation windowAnimation;
}

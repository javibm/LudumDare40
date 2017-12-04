using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAnimation : MonoBehaviour {


	void Start ()
	{
		if(GameMetaManager.Instance != null)
		{
			GameMetaManager.Employee.OnEmployeeWindow += PlayAnimationOpen;
			GameMetaManager.Employee.OnEmployeeClosed += PlayAnimationClose;
			animatorController = GetComponent<Animator>();
		}
	}

	private void PlayAnimationOpen(WindowPoint window)
	{
		if(window.WindowAnimation == this)
		{
			animatorController.CrossFade("Open", 0.0f);
		}
	}

	private void PlayAnimationClose(WindowPoint window)
	{
		if(window.WindowAnimation == this)
		{
			animatorController.CrossFade("Close", 0.0f);
		}
	}

	private Animator animatorController;
}

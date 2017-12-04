using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

	void Start ()
	{
		if(GameMetaManager.Instance != null)
		{
			GameMetaManager.Employee.OnEmployeeCreated += PlayAnimation;
			GameMetaManager.Employee.OnDoorFired += PlayAnimation;
			animatorController = GetComponent<Animator>();
		}
	}

	private void PlayAnimation()
	{
		animatorController.CrossFade("Door", 0.0f);
	}

	private Animator animatorController;
}

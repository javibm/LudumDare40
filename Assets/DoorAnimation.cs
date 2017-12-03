using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DoorAnimation : MonoBehaviour {

	void Start ()
	{
		GameMetaManager.Employee.OnEmployeeCreated += PlayAnimation;
		animatorController = GetComponent<Animator>();
	}

	private void PlayAnimation()
	{
		animatorController.CrossFade("Door", 0.0f);
	}

	private Animator animatorController;
}

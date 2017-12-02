using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Actions/Request")]
public class RequestAction : Action {

	public override void Act(EmployeeController controller)
	{
		WaitingForRequest(controller);
	}

	private void WaitingForRequest(EmployeeController controller)
	{
		controller.EmployeeStateController.IncreaseLastActionTime();
		if (Input.anyKeyDown)
		{
			controller.EmployeeStateController.ForceWorkAgain();
		}
		Debug.Log ("WAITING FOR REQUEST");
	}
}

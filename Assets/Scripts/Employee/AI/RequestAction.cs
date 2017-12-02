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
		if (Input.anyKey)
		{
			controller.EmployeeStateController.AcceptRequest(controller);
		}
		else if(controller.EmployeeStateController.LastActionTime > controller.EmployeeStateController.NextRequestTime)
		{
			controller.EmployeeStateController.ForceWorkAgain();
		}
		Debug.Log ("WAITING FOR REQUEST");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Actions/Request")]
public class RequestAction : Action {

	public override void Act(EmployeeStateController controller)
	{
		WaitingForRequest(controller);
	}

	private void WaitingForRequest(EmployeeStateController controller)
	{
		controller.IncreaseLastActionTime();
		if (Input.anyKeyDown)
		{
			controller.EndRequest(false);
		}
		Debug.Log ("WAITING FOR REQUEST");
	}
}

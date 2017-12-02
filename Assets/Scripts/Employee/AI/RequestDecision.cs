using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Request")]
public class RequestDecision : Decision {

	public override bool Decide(EmployeeStateController controller)
	{
		return Request(controller);
	}

	private bool Request(EmployeeStateController controller)
	{
		controller.IncreaseLastActionTime();
		return controller.LastActionTime >= controller.NextRequestTime;
	}

}

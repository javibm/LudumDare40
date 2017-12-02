using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Request")]
public class RequestDecision : Decision {

	public override bool Decide(EmployeeController controller)
	{
		return Request(controller);
	}

	private bool Request(EmployeeController controller)
	{
		return controller.EmployeeStateController.LastActionTime >= controller.EmployeeStateController.NextRequestTime;
	}

}

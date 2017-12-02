using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Procrastinate")]
public class ProcrastinateDecision : Decision {

	public override bool Decide(EmployeeController controller)
	{
		return Procrastinate(controller);
	}

	private bool Procrastinate(EmployeeController controller)
	{
		return controller.EmployeeStateController.LastActionTime >= controller.EmployeeStateController.NextProcrastinationTime;
	}

}

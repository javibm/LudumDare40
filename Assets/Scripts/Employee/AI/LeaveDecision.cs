using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Leave")]
public class LeaveDecision : Decision {

	public override bool Decide(EmployeeController controller)
	{
		return LeaveOffice(controller);
	}

	private bool LeaveOffice(EmployeeController controller)
	{
		return controller.EmployeeStateController.RequestFinished && controller.EmployeeStateController.Happiness <= 0;
	}

}

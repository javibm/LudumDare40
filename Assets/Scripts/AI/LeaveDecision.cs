using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Leave")]
public class LeaveDecision : Decision {

	public override bool Decide(EmployeeStateController controller)
	{
		return LeaveOffice(controller);
	}

	private bool LeaveOffice(EmployeeStateController controller)
	{
		return controller.RequestFinished && controller.Happiness <= 0;
	}

}

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
		bool requestCompleted = controller.EmployeeStateController.ForceWork;
		bool waitTimeUp = controller.EmployeeStateController.LastActionTime >= controller.EmployeeStateController.NextRequestTime;
		if (requestCompleted || waitTimeUp)
		{
			controller.OnRequestAnswered(false);
		}
		return (requestCompleted || waitTimeUp) && controller.EmployeeStateController.Happiness <= 0;	
	}

}

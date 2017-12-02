using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Work Again")]
public class WorkAgainDecision : Decision {

	public override bool Decide(EmployeeController controller)
	{
		return GoToWork(controller);
	}

	private bool GoToWork(EmployeeController controller)
	{
		return controller.EmployeeStateController.RequestFinished && controller.EmployeeStateController.Happiness > 0;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Work Again")]
public class WorkAgain : Decision {

	public override bool Decide(EmployeeStateController controller)
	{
		return GoToWork(controller);
	}

	private bool GoToWork(EmployeeStateController controller)
	{
		return controller.RequestFinished && controller.Happiness > 0;
	}

}

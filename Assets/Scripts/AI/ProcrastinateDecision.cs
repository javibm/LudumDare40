using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Decisions/Procrastinate")]
public class ProcrastinateDecision : Decision {

	public override bool Decide(EmployeeStateController controller)
	{
		return Procrastinate(controller);
	}

	private bool Procrastinate(EmployeeStateController controller)
	{
		return controller.Happiness < 0.4f;
	}

}

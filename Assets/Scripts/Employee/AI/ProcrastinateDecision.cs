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
		float randomProcrastination = Random.Range(0.0f, 1.0f);
		bool startProcrastination = randomProcrastination > controller.EmployeeStateController.Happiness;
		if (controller.EmployeeStateController.LastActionTime >= controller.EmployeeStateController.NextProcrastinationTime)
		{
			controller.EmployeeStateController.ResetTimes();
			return startProcrastination;
		}
		return false;
	}
}

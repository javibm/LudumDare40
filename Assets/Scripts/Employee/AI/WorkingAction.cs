using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Actions/Working")]
public class WorkingAction : Action {

	public override void Act(EmployeeController controller)
	{
		ProduceResources(controller);
	}

	private void ProduceResources(EmployeeController controller)
	{
		controller.EmployeeStateController.IncreaseLastActionTime();
		controller.EmployeeMovementController.MoveToDesk();
		Debug.Log ("PRODUCE " + Time.deltaTime + " MONEY MONEY MONEY!");
	}
}

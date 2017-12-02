using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Actions/Working")]
public class WorkingAction : Action {

	public override void Act(EmployeeStateController controller)
	{
		ProduceResources(controller);
	}

	private void ProduceResources(EmployeeStateController controller)
	{
		controller.Happiness -= Time.deltaTime;
		Debug.Log ("PRODUCE " + Time.deltaTime + " MONEY MONEY MONEY!");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Actions/Leave")]
public class LeaveAction : Action {

	public override void Act(EmployeeController controller)
	{
		LeaveTheOffice(controller);
	}

	private void LeaveTheOffice(EmployeeController controller)
	{
		Debug.Log("RAGEQUIT");
		Destroy(controller.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Actions/Leave")]
public class LeaveAction : Action {

	public override void Act(EmployeeStateController controller)
	{
		LeaveTheOffice(controller);
	}

	private void LeaveTheOffice(EmployeeStateController controller)
	{
		Debug.Log("RAGEQUIT");
	}
}

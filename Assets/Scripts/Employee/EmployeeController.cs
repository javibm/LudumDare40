using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

	public float MoneyGenerated
	{
		get;
		set;
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		employeeStateController = GetComponent<EmployeeStateController>();
		employeeMovementController = GetComponent<EmployeeMovementController>();
	}

	public EmployeeController(float moneyGenerated)
	{
		MoneyGenerated = moneyGenerated;
	}

	private EmployeeStateController employeeStateController;
	private EmployeeMovementController employeeMovementController;
}

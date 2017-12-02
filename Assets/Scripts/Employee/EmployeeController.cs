using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

	public float MoneyGenerated
	{
		get;
		set;
	}

	public EmployeeStateController EmployeeStateController
	{
		get
		{
			return employeeStateController;
		}
	}

	public EmployeeMovementController EmployeeMovementController
	{
		get
		{
			return employeeMovementController;
		}
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		employeeStateController = GetComponent<EmployeeStateController>();
		employeeMovementController = GetComponent<EmployeeMovementController>();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
			employeeStateController.UpdateState(this);
	}

	public EmployeeController(float moneyGenerated)
	{
		MoneyGenerated = moneyGenerated;
	}

	private EmployeeStateController employeeStateController;
	private EmployeeMovementController employeeMovementController;
}

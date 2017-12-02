using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour {

	public int MoneyGenerated
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

	public void Init(OfficeDesk officeDesk, int moneyGenerated)
	{
		employeeStateController = GetComponent<EmployeeStateController>();
		employeeMovementController = GetComponent<EmployeeMovementController>();

		employeeMovementController.Init(officeDesk, GetComponent<NavMeshController>());

		MoneyGenerated = moneyGenerated;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
			employeeStateController.UpdateState(this);
	}

	public void GenerateMoney()
	{
		timeSinceLastGeneration += Time.deltaTime;
		if (timeSinceLastGeneration > 1)
		{
			GameMetaManager.Money.AddMoney(MoneyGenerated);
			timeSinceLastGeneration = 0;
		}
	}

	private EmployeeStateController employeeStateController;
	private EmployeeMovementController employeeMovementController;
	private float timeSinceLastGeneration;
}

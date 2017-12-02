using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EmployeeController : MonoBehaviour {

	public EmployeeStateController EmployeeStateController
	{
		get;
		private set;
	}

	public EmployeeMovementController EmployeeMovementController
	{
		get;
		private set;
	}

	public void Init(OfficeDesk officeDesk)
	{
		EmployeeStateController = GetComponent<EmployeeStateController>();
		EmployeeMovementController = GetComponent<EmployeeMovementController>();

		EmployeeMovementController.Init(officeDesk, GetComponent<NavMeshController>(), GetComponent<EmployeeAnimationController>());
	}

	void Update()
	{
		if (holidayEnd == 0)
		{
			EmployeeStateController.UpdateState(this);
		}
	}

	public void GenerateMoney()
	{
		timeSinceLastGeneration += Time.deltaTime;
		if (timeSinceLastGeneration > 1)
		{
			GameMetaManager.Money.AddMoney(employeeStats.MoneyGenerated);
			timeSinceLastGeneration = 0;
		}
	}

	public void ApplyRequest()
	{
		Debug.Log("REQUEST " + nextRequest);
		if (nextRequest == RequestType.PayRaise)
		{
			GameMetaManager.Money.RemoveMoney(UnityEngine.Random.Range(employeeStats.MinPayRaise, employeeStats.MaxPayRaise));
		}
		else if (nextRequest == RequestType.Holidays)
		{
			TakeHolidays();
		}
		SetNextRequest();
	}
	public void TakeHolidays()
	{
		GetComponentInChildren<Renderer>().enabled = false;
		holidayEnd = employeeStats.HolidayTime;
		GameMetaManager.Time.OnDayPassed += CheckEndOfHolidays;
	}

	public void CheckEndOfHolidays()
	{
		if (holidayEnd != 0)
		{
			holidayEnd--;
		}
		if (holidayEnd == 0)
		{
			GetComponentInChildren<Renderer>().enabled = true;
			GameMetaManager.Time.OnDayPassed -= CheckEndOfHolidays;
		}
	}

	public void SetNextRequest()
	{
		nextRequest = (RequestType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(RequestType)).Length);
	}

	private enum RequestType
	{
		PayRaise,
		Holidays
	}

	private RequestType nextRequest;

	private float timeSinceLastGeneration;
	private int holidayEnd;

	[SerializeField]
	private EmployeeStats employeeStats;
}

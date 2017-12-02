using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMetaManager : Singleton<GameMetaManager> 
{
	public static OfficeManager Office
	{
		get
		{
			return Instance.office;
		}
	}

	public static MoneyManager Money
	{
		get
		{
			return Instance.money;
		}
	}

	protected new void Awake()
	{
		base.Awake();
		office = new OfficeManager(officeInitialSize, officeGenerator, officeStats);
		money = new MoneyManager(initialMoney);
		employees = new EmployeeManager(employeeGenerator);

		//TO DO INSTANCIACION DE PRUEBA
		employees.CreateNewEmployee(office.DeskList[0]);
	}

	private OfficeManager office;
	private MoneyManager money;
	private EmployeeManager employees;

	[SerializeField]
	private int officeInitialSize = 2;
	[SerializeField]
	private int initialMoney = 1000;
	[SerializeField]
	private OfficeGenerator officeGenerator;
	[SerializeField]
	private OfficeStats officeStats;
	[SerializeField]
	private EmployeeGenerator employeeGenerator;
}

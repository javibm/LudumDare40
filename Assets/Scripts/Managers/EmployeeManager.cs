using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager {

	public List<EmployeeController> EmployeeList
	{
		get;
		private set;
	}

	public EmployeeStats EmployeeStats
	{
		get{return employeeStats;}
	}

	public int CurrentEmployees
	{
		get
		{
			return EmployeeList.Count;
		}
	}

	public EmployeeManager(EmployeeGenerator employeeGenerator, EmployeeStats employeeStats)
	{
		this.employeeGenerator = employeeGenerator;
		this.employeeStats = employeeStats;
    EmployeeList = new List<EmployeeController>();
		//TO-DO ESTO ES UNA INSTANCIACIÓN DE PRUEBA!
	}
	
	public void CreateNewEmployee(OfficeDesk officeDesk, float happiness)
	{
		EmployeeController employeeController = employeeGenerator.InstantiateEmployeePrefab(officeDesk.transform);
		employeeController.Init(officeDesk, happiness);
    EmployeeList.Add(employeeController);
  }

	public bool TryCreateNewEmployee(int money, float happiness)
	{
    if (GameMetaManager.Office.GetEmptyDeskCount() > 0)
    {
      CreateNewEmployee(GameMetaManager.Office.GetEmptyDesk(), happiness);
			GameMetaManager.Money.RemoveMoney(money);
			return true;
    }
		else
		{
			return false;
		}
	}


	private EmployeeGenerator employeeGenerator;

	private EmployeeStats employeeStats;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager {

	public List<EmployeeController> EmployeeList
	{
		get;
	}

	public int CurrentEmployees
	{
		get
		{
			return EmployeeList.Count;
		}
	}

	public EmployeeManager(EmployeeGenerator employeeGenerator)
	{
		this.employeeGenerator = employeeGenerator;
    EmployeeList = new List<EmployeeController>();
		//TO-DO ESTO ES UNA INSTANCIACIÓN DE PRUEBA!
	}
	
	public void CreateNewEmployee(OfficeDesk officeDesk)
	{
		EmployeeController employeeController = employeeGenerator.InstantiateEmployeePrefab();
		employeeController.Init(officeDesk);
    EmployeeList.Add(employeeController);
  }


	private EmployeeGenerator employeeGenerator;

}

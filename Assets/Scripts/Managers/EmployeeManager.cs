using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager {

	public List<EmployeeController> EmployeeList
	{
		get
		{
			return EmployeeList;
		}
	}

	public EmployeeManager(EmployeeGenerator employeeGenerator)
	{
		this.employeeGenerator = employeeGenerator;

		//TO-DO ESTO ES UNA INSTANCIACIÓN DE PRUEBA!
	}
	
	public void CreateNewEmployee(OfficeDesk officeDesk)
	{
		EmployeeController employeeController = employeeGenerator.InstantiateEmployeePrefab();
		employeeController.Init(officeDesk);
	}


	private EmployeeGenerator employeeGenerator;

}

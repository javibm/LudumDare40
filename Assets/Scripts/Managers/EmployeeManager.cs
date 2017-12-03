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

	public System.Action OnEmployeeCreated;
	public System.Action<WindowPoint> OnEmployeeWindow;

	public System.Action<WindowPoint> OnEmployeeClosed;

	public EmployeeManager(EmployeeGenerator employeeGenerator, EmployeeStats employeeStats)
	{
		this.employeeGenerator = employeeGenerator;
		this.employeeStats = employeeStats;
    EmployeeList = new List<EmployeeController>();
		//TO-DO ESTO ES UNA INSTANCIACIÓN DE PRUEBA!
	}
	
	public void CreateNewEmployee(OfficeDesk officeDesk, float happiness)
	{
		EmployeeController employeeController = employeeGenerator.InstantiateEmployeePrefab(GameMetaManager.Office.DoorPoint);
		employeeController.OnHolidayTaked += officeDesk.HolidayDesk.ActivateHolidayCartel;
		employeeController.Init(officeDesk, happiness);
    EmployeeList.Add(employeeController);
  }

	public bool TryCreateNewEmployee(int money, float happiness)
	{
    if (GameMetaManager.Office.GetEmptyDeskCount() > 0)
    {			
      CreateNewEmployee(GameMetaManager.Office.GetEmptyDesk(), happiness);
			GameMetaManager.Money.RemoveMoney(money);
			if(OnEmployeeCreated != null)
			{
				OnEmployeeCreated();
			}
			return true;
    }
		else
		{
			return false;
		}
	}

	public void ReleaseEmployee(EmployeeController employeeController)
	{
		employeeController.EmployeeMovementController.ReleaseDesk();
		EmployeeList.Remove(employeeController);
	}


	private EmployeeGenerator employeeGenerator;

	private EmployeeStats employeeStats;
}

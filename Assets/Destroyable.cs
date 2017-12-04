using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour 
{
	public void DestroyMe()
	{
		GetComponent<EmployeeParticlesController>().PlayWindowParticles();
		GetComponent<EmployeeController>().DestroyEmployee();
	}

	public void InitScream()
	{
		GameMetaManager.Employee.OnRageWindow();
	}
}

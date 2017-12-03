using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	public void DestroyMe()
	{
		GetComponent<EmployeeParticlesController>().PlayWindowParticles();
		GameMetaManager.Employee.ReleaseEmployee(GetComponent<EmployeeController>());
		Destroy(gameObject);
	}
}

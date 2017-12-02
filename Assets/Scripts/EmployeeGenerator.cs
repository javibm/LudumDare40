using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeGenerator : MonoBehaviour {

	public EmployeeController InstantiateEmployeePrefab()
	{
		return Instantiate(getRandomEmployeePrefab(), Vector3.zero, Quaternion.identity).GetComponent<EmployeeController>();
	}

	private GameObject getRandomEmployeePrefab()
	{
		return employees[Random.Range(0, employees.Length)];
	}

	[SerializeField]
	private GameObject[] employees;
}

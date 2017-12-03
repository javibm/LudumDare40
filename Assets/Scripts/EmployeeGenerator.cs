using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeGenerator : MonoBehaviour {

	public EmployeeController InstantiateEmployeePrefab(Transform transform)
	{
		return Instantiate(getRandomEmployeePrefab(), transform.position, Quaternion.identity).GetComponent<EmployeeController>();
	}

	private GameObject getRandomEmployeePrefab()
	{
		return employees[Random.Range(0, employees.Length)];
	}

	[SerializeField]
	private GameObject[] employees;
}

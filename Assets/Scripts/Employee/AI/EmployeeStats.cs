using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Stats")]
public class EmployeeStats : ScriptableObject {
	[Header("Request Times")]
	public float minRequestTime = 3;
	public float maxRequestTime = 10;

	[Header("Procrastinate Times")]
	public float minProcrastinateTime = 3;
	public float maxProcrastinateTime = 10;

	[Header("Initial Happiness")]
	public float minInitialHappiness = 0.7f;
	public float maxInitialHappiness = 1.0f;

	[Header("Happiness Changes")]
	public float requestAcceptedHappiness = 0.3f;
	public float requestDeniedHappiness = 0.4f;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee AI/Stats")]
public class EmployeeAIStats : ScriptableObject {
	[Header("Request Times")]
	public float minRequestTime = 3;
	public float maxRequestTime = 10;

	[Header("Procrastinate Times")]
	public float minProcrastinateTime = 3;
	public float maxProcrastinateTime = 10;

	[Header("Happiness Changes")]
	public float requestAcceptedHappiness = 0.3f;
	public float requestDeniedHappiness = 0.4f;
}

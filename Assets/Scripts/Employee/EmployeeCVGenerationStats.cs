using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee/CVGenerationStats")]
public class EmployeeCVGenerationStats : ScriptableObject
{
	public int DaysBeforeFirstCV;
	public int MinDaysForNextCV;
	public int MaxDaysForNextCV;
}

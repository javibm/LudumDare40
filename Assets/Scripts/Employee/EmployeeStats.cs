using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee/Stats")]
public class EmployeeStats : ScriptableObject {
	public int MoneyGenerated = 5;
	public int HolidayTime = 15;
	public int MinPayRaise = 10;
	public int MaxPayRaise = 20;

	[Header("Initial Happiness")]
	public float minInitialHappiness = 0.7f;
	public float maxInitialHappiness = 1.0f;

	public float moneyFactor = 1f;
	public float payRaiseProbability = 0.75f;
}

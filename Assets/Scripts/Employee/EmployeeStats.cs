using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Employee/Stats")]
public class EmployeeStats : ScriptableObject {
	public int MoneyGenerated = 5;
	public int HolidayTime = 15;
	public int MinPayRaise = 10;
	public int MaxPayRaise = 20;
	public int MoneyCost = 10;
}

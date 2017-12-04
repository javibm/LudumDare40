using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "GameStats")]
public class GameStats : ScriptableObject
{
	public int DayDurationInSeconds;
	public int InitialMoney;
	public int MaxDaysWithNegativeMoney;
	public int OfficeInitialSize;
}

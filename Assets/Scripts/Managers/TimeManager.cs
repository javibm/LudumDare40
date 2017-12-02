using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	public int DaysPassed
	{
		get;
		private set;
	}

	public event System.Action OnDayPassed;

	void Start()
	{
		DaysPassed = 0;
		StartCoroutine(DaysCounter(gameStats.DayDurationInSeconds));
	}

	private IEnumerator DaysCounter(int daySecondsDuration)
	{
		while(true)
		{
			yield return new WaitForSeconds(daySecondsDuration);
			DaysPassed++;
			NotifyOnDayPassed();
		}
	}

	private void NotifyOnDayPassed()
	{
		if(OnDayPassed != null)
		{
			OnDayPassed();
		}
	}

	[SerializeField]
	private GameStats gameStats;
}

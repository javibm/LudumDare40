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
		GameMetaManager.OnLoseGame += OnLoseGame;
		DaysPassed = 0;
		StartCoroutine(DaysCounter(gameStats.DayDurationInSeconds));
	}

	void OnDestroy()
	{
		GameMetaManager.OnLoseGame -= OnLoseGame;
	}
	

	private void OnLoseGame()
	{
		StopAllCoroutines();
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

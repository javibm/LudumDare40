using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVManager  
{
	public EmployeeCV PendingCV
	{
		get;
		private set;
	}

	public CVManager(EmployeeCVGenerationStats cvGenerationStats)
	{
		daysForNextCV = cvGenerationStats.DaysBeforeFirstCV;
		this.cvGenerationStats = cvGenerationStats;
		PendingCV = null;
		resetDaysForNextCV();
	}

	public event System.Action OnNewCVGenerated;

	public void Init()
	{
		GameMetaManager.Time.OnDayPassed += OnDayPassed;
	}

	public void AcceptPendingCV()
	{
		PendingCV = null;
		resetDaysForNextCV();
	}

	public void RejectPendingCV()
	{
		PendingCV = null;
		resetDaysForNextCV();
	}

	private void OnDayPassed()
	{
		daysForNextCV--;
		if(daysForNextCV <= 0 && PendingCV == null)
		{
			generateNewCV();
		}
	}

	private void generateNewCV()
	{
		PendingCV = new EmployeeCV();
		if(OnNewCVGenerated != null)
		{
			OnNewCVGenerated();
		}
	}

	private void resetDaysForNextCV()
	{
		if(firstCVGenerated == false)
		{
			daysForNextCV = cvGenerationStats.DaysBeforeFirstCV;
			firstCVGenerated = true;
		}
		else
		{
			daysForNextCV = (int)Random.Range(cvGenerationStats.MinDaysForNextCV, cvGenerationStats.MaxDaysForNextCV + 1);
		}
	}

	private int daysForNextCV = 0;
	private bool firstCVGenerated = false;
	private EmployeeCVGenerationStats cvGenerationStats;
}

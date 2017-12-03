using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeStateController : MonoBehaviour {

	public float Happiness
	{
		get;
		set;
	}

	public float LastActionTime
	{
		get;
		set;
	}

	public float NextProcrastinationTime
	{
		get;
		set;
	}

	public float NextRequestTime
	{
		get;
		set;
	}

	public bool ForceWork
	{
		get;
		set;
	}

	public EmployeeAIStats EmployeeAIStats
	{
		get
		{
			return employeeAIStats;
		}
	}

	public EmployeeStats EmployeeStats
	{
		get {return GameMetaManager.Employee.EmployeeStats;}
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		Happiness = Random.Range(EmployeeStats.minInitialHappiness, EmployeeStats.maxInitialHappiness);
		ResetTimes();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	public void UpdateState(EmployeeController employeeController)
	{
			currentState.UpdateState (employeeController);
	}

	public void IncreaseLastActionTime()
	{
		LastActionTime += Time.deltaTime;
	}

	public void UpdateState(State nextState)
	{
		if (currentState != nextState)
		{
			currentState = nextState;
			ResetTimes();
		}
	}

	public void ResetTimes()
	{
		LastActionTime = 0;
		NextProcrastinationTime = Random.Range(employeeAIStats.minProcrastinateTime, employeeAIStats.maxProcrastinateTime);
		NextRequestTime = Random.Range(employeeAIStats.minRequestTime, employeeAIStats.maxRequestTime);
		ForceWork = false;
	}

	public void AcceptRequest()
	{
		ForceWork = true;
		Happiness += employeeAIStats.requestAcceptedHappiness;
	}

	public void ForceWorkAgain()
	{
		ForceWork = true;
		Happiness -= employeeAIStats.requestDeniedHappiness;
	}

	[SerializeField]
	private State currentState;

	[SerializeField]
	private EmployeeAIStats employeeAIStats;
}

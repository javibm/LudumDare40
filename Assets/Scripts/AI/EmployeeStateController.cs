using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeStateController : MonoBehaviour {

	public float Happiness
	{
		get;
		set;
	}

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
			Happiness = 1;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
			currentState.UpdateState (this);
	}

	public void UpdateState(State nextState)
	{
		if (currentState != nextState)
		{
			currentState = nextState;
		}
	}

	[SerializeField]
	private State currentState;
}

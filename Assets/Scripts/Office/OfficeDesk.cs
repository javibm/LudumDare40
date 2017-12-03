using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeDesk : MonoBehaviour 
{
	public Transform Transform
	{
		get;
		private set;
	}

	public bool Filled
	{
		get;
		set;
	}

	public SetAnimationDesk HolidayDesk
	{
		get { return setAnimationDesk; }
	}

	void Awake()
	{
		Transform = gameObject.transform;
		setAnimationDesk = GetComponent<SetAnimationDesk>();
	}

	private SetAnimationDesk setAnimationDesk;
}

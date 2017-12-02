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

	public bool Taken
	{
		get;
		set;
	}

	void Awake()
	{
		Transform = gameObject.transform;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Request : MonoBehaviour {

	public enum RequestType
	{
		PayRaise,
		Holidays
	}

	public RequestType CurrentRequestType
	{
		get;
		private set;
	}

	public Request()
	{
		CurrentRequestType = (RequestType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(RequestType)).Length);
	}

}

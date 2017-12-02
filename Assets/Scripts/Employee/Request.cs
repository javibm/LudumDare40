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

	public int requestValue;

	public RequestType CurrentRequestType
	{
		get;
		private set;
	}

	public Request(int money, int holidays)
	{
		CurrentRequestType = (RequestType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(RequestType)).Length);
		if (CurrentRequestType == RequestType.PayRaise)
		{
			requestValue = money;
		}
		else if (CurrentRequestType == RequestType.Holidays)
		{
			requestValue = holidays;
		}
	}

	public void ApplyRequest()
	{
		if (CurrentRequestType == RequestType.PayRaise)
		{
			GameMetaManager.Money.RemoveMoney(requestValue);
		}
		else if (CurrentRequestType == RequestType.Holidays)
		{
			//TODO ON HOLIDAY!
		}
	}

}

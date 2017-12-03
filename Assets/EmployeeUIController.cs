using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeUIController : MonoBehaviour {

	public System.Action<bool> OnRequestAnswered = delegate {};

	public void EnableUI(EmployeeController.RequestType requestType)
	{
		if (requestClicked)
		{
		  EnableAnswerRequest();
		}
		else if (requestType == EmployeeController.RequestType.PayRaise)
		{
			EnablePayRaise();
		}
		else if (requestType == EmployeeController.RequestType.Holidays)
		{
			EnableHolidays();
		}
	}

	public void EnablePayRaise()
	{
		DisableAll();
		payRaise.SetActive(true);
	}

	public void EnableHolidays()
	{
		DisableAll();
		holidays.SetActive(true);
	}

	public void EnableAnswerRequest()
	{
		requestClicked = true;
		DisableAll();
		answerRequest.SetActive(true);
	}

	public void DisableAll()
	{
		payRaise.SetActive(false);
		holidays.SetActive(false);
		answerRequest.SetActive(false);
	}

	public void AcceptRequest()
	{
		OnRequestAnswered(true);
	}

	public void DeclineRequest()
	{
		OnRequestAnswered(false);
	}

	[SerializeField]
	private GameObject payRaise;

	[SerializeField]
	private GameObject holidays;

	[SerializeField]
	private GameObject answerRequest;

	private bool requestClicked = false;
}

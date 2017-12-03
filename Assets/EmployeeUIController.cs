using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeUIController : MonoBehaviour {

	public System.Action<bool> OnRequestAnswered = delegate {};

	public void EnableUI(EmployeeController.RequestType requestType, string text)
	{
		if (requestClicked)
		{
		  EnableAnswerRequest();
		}
		else if (requestType == EmployeeController.RequestType.PayRaise)
		{
			EnablePayRaise(text);
		}
		else if (requestType == EmployeeController.RequestType.Holidays)
		{
			EnableHolidays(text);
		}
	}

	public void EnablePayRaise(string text)
	{
		DisableAll();
		payRaise.SetActive(true);
		payRaiseText.text = text;
	}

	public void EnableHolidays(string text)
	{
		DisableAll();
		holidays.SetActive(true);
		holidaysText.text = text;
	}

	public void EnableAnswerRequest()
	{
		requestClicked = true;
		DisableAll();
		answerRequest.SetActive(true);
	}

	public void CloseRequest()
	{
		requestClicked = false;
		DisableAll();
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

	[SerializeField]
	private Text payRaiseText;

	[SerializeField]
	private Text holidaysText;

	private bool requestClicked = false;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils.UI;

public class EmployeeUIController : MonoBehaviour {

	public System.Action<bool> OnRequestAnswered = delegate {};
	public System.Action OnForceWork = delegate {};

	public System.Action OnFired = delegate {};

	void Start()
	{
		moneyBalanceChange.gameObject.SetActive(false);
	}

	public void EnableUI(EmployeeController.RequestType requestType, string text)
	{
		if (requestType == EmployeeController.RequestType.PayRaise)
		{
			EnablePayRaise(text);
		}
		else if (requestType == EmployeeController.RequestType.Holidays)
		{
			EnableHolidays(text);
		}
	}

	public void EnableForceWork()
	{
		DisableAll();
		forceWork.SetActive(true);
	}

	public void EnableFire()
	{
		DisableAll();
		fire.SetActive(true);
	}

	public void EnablePayRaise(string text)
	{
		DisableAll();
		payRaise.SetActive(true);
		answerRequest.SetActive(true);
		payRaiseText.text = text;
	}

	public void EnableHolidays(string text)
	{
		DisableAll();
		holidays.SetActive(true);
		answerRequest.SetActive(true);
		holidaysText.text = text;
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
		forceWork.SetActive(false);
		fire.SetActive(false);
	}

	public void ForceWork()
	{
		OnForceWork();
	}

	public void AcceptRequest()
	{
		GameMetaManager.Employee.OnAnswerYay();
		OnRequestAnswered(true);
	}

	public void DeclineRequest()
	{
		GameMetaManager.Employee.OnAnswerCry();
		OnRequestAnswered(false);
	}

	public void Fire()
	{
		OnFired();
	}

	public void EnableMoneyChange(int money)
	{
		moneyBalanceChange.AddOnFinishedCallback(DisableMoneyChange);
		moneyBalanceChangeText.text = money.ToString();
		moneyBalanceChange.gameObject.SetActive(true);
	}

	private void DisableMoneyChange()
	{
		moneyBalanceChange.ResetTweener();
		moneyBalanceChange.gameObject.SetActive(false);
	}

	[Header("Money Change")]
	[SerializeField]
	private Tweener moneyBalanceChange;
	[SerializeField]
	private Text moneyBalanceChangeText;

	[Header("Force Work")]
	[SerializeField]
	private GameObject forceWork;

	[Header("Fire")]
	[SerializeField]
	private GameObject fire;

	[Header("Requests")]
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

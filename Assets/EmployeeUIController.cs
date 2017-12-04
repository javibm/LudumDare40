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
		happyFace.gameObject.SetActive(false);
		angryFace.gameObject.SetActive(false);
	}

	public void EnableUI(EmployeeController.RequestType requestType, string text)
	{
		if (requestType == EmployeeController.RequestType.PayRaise)
		{
			EnablePayRaise("$"+text);
		}
		else if (requestType == EmployeeController.RequestType.Holidays)
		{
			EnableHolidays(text);
		}
	}

	private GameObject activeObject = null;

	public void EnableForceWork()
	{
		if(activeObject != forceWork)
		{
			DisableAll();
			forceWork.SetActive(true);
			activeObject = forceWork;
		}
	}

	public void EnableFire()
	{
		if(activeObject != fire)
		{
			DisableAll();
			fire.SetActive(true);
			activeObject = fire;
		}
	}

	public void EnablePayRaise(string text)
	{
		if(activeObject != payRaise)
		{
			DisableAll();
			payRaise.SetActive(true);
			answerRequest.SetActive(true);
			activeObject = payRaise;
		}
		payRaiseText.text = text;
	}

	public void EnableHolidays(string text)
	{
		if(activeObject != holidays)
		{
			DisableAll();
			holidays.SetActive(true);
			answerRequest.SetActive(true);
			activeObject = holidays;
		}
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

		activeObject = null;
	}

	public void ForceWork()
	{
		OnForceWork();
	}

	public void AcceptRequest()
	{
		GameMetaManager.Employee.OnAnswerYay();
		happyFace.gameObject.SetActive(true);
		OnRequestAnswered(true);
	}

	public void DeclineRequest()
	{
		GameMetaManager.Employee.OnAnswerCry();
		angryFace.gameObject.SetActive(true);
		OnRequestAnswered(false);
	}

	public void Fire()
	{
		OnFired();
	}

	public void EnableMoneyChange(int money)
	{
		moneyBalanceChange.AddOnFinishedCallback(DisableMoneyChange);
		moneyBalanceChangeText.color = money > 0 ? greenColor : redColor;
		moneyBalanceChangeText.text = (money > 0 ? "+" : "") + money.ToString() +" $";
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

	[Header("Money Colors")]
	[SerializeField]
	private Color greenColor;
	[SerializeField]
	private Color redColor;

	[Header("Faces")]
	[SerializeField]
	private Tweener happyFace;

	[SerializeField]
	private Tweener angryFace;

	private bool requestClicked = false;
}

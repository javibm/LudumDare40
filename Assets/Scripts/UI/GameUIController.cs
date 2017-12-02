using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour 
{
	void Awake()
	{
		// Buttons listeners
		expandOfficeButton.onClick.AddListener(OnExpandOfficeButtonClick);
	}
	
	void Start () 
	{
		// Eventos
		GameMetaManager.Money.OnMoneyChanged += OnMoneyChanged;
		GameMetaManager.Money.OnMoneyChangeToNegative += OnMoneyChangeToNegative;
		GameMetaManager.Money.OnMoneyChangeToPositive += OnMoneyChangeToPositive;
		GameMetaManager.Time.OnDayPassed += OnDayPassed;
		GameMetaManager.OnLoseGame += OnLoseGame;

		UpdateMoney();
		UpdateDaysPassed();
		ShowDaysWithNegativeMoneyTimer(false);
		ShowGameOverText(false);
	}

	private void OnExpandOfficeButtonClick()
	{
		GameMetaManager.Office.TryExpand();
	}

	private void OnMoneyChanged()
	{
		UpdateMoney();
	}

	private void OnMoneyChangeToNegative()
	{
		UpdateMoney();
		ShowDaysWithNegativeMoneyTimer(true);
	}

	private void OnMoneyChangeToPositive()
	{
		UpdateMoney();
		ShowDaysWithNegativeMoneyTimer(false);
	}

	private void OnDayPassed()
	{
		UpdateDaysPassed();
		daysWithNegativeMoneyTimerImage.transform.localScale = new Vector2((float)GameMetaManager.DaysWithNegativeMoney / (float)GameMetaManager.MaxDaysWithNegativeMoney, 1f);
	}

	private void OnLoseGame()
	{
		ShowGameOverText(true);
		GameMetaManager.Time.OnDayPassed -= OnDayPassed;
	}
	
	private void UpdateMoney()
	{
		moneyLabelText.text = GameMetaManager.Money.CurrentMoney.ToString();
	}

	private void UpdateDaysPassed()
	{
		daysPassedLabelText.text = GameMetaManager.Time.DaysPassed.ToString();
	}

	private void ShowDaysWithNegativeMoneyTimer(bool show)
	{
		daysWithNegativeMoneyTimerGameObject.SetActive(show);
	}

	private void ShowGameOverText(bool show)
	{
		gameOverLabelText.gameObject.SetActive(show);
	}
	
	[SerializeField]
	private Text moneyLabelText;
	
	[SerializeField]
	private Text daysPassedLabelText;

	[SerializeField]
	private GameObject daysWithNegativeMoneyTimerGameObject;
	[SerializeField]
	private Image daysWithNegativeMoneyTimerImage;

	[SerializeField]
	private Button expandOfficeButton;

	[SerializeField]
	private Text gameOverLabelText;
}

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
		cvAcceptButton.onClick.AddListener(OnCVAcceptButtonClick);
		cvRejectButton.onClick.AddListener(OnCVRejectButtonClick);
	}
	
	void Start () 
	{
		// Eventos
		GameMetaManager.Money.OnMoneyChanged += OnMoneyChanged;
		GameMetaManager.Money.OnMoneyChangeToNegative += OnMoneyChangeToNegative;
		GameMetaManager.Money.OnMoneyChangeToPositive += OnMoneyChangeToPositive;
		GameMetaManager.Time.OnDayPassed += OnDayPassed;
		GameMetaManager.CVs.OnNewCVGenerated += OnNewCVGenerated;
		GameMetaManager.OnLoseGame += OnLoseGame;

		UpdateMoney();
		UpdateDaysPassed();
		UpdateProgressBar();
		ShowCV(false);
		ShowGameOverText(false);
	}

	private void OnExpandOfficeButtonClick()
	{
		GameMetaManager.Office.TryExpand();
	}

	private void OnCVAcceptButtonClick()
	{
		GameMetaManager.Employee.TryCreateNewEmployee(GameMetaManager.CVs.PendingCV.MoneyCost, GameMetaManager.CVs.PendingCV.Happiness);
		GameMetaManager.CVs.AcceptPendingCV();
		ShowCV(false);
	}
	private void OnCVRejectButtonClick()
	{
		GameMetaManager.CVs.RejectPendingCV();
		ShowCV(false);
	}

	private void OnMoneyChanged()
	{
		UpdateMoney();
		UpdateProgressBar();
	}

	private void OnMoneyChangeToNegative()
	{
		UpdateMoney();
	}

	private void OnMoneyChangeToPositive()
	{
		UpdateMoney();
	}

	private void OnDayPassed()
	{
		UpdateDaysPassed();
		UpdateProgressBar();
	}

	private void OnNewCVGenerated()
	{
		EmployeeCV cv = GameMetaManager.CVs.PendingCV;
		cvNameText.text = string.Format(cvText, cv.Name);
		cvMoneyText.text = string.Format(moneyText, cv.MoneyCost.ToString("0.00"));
		cvMotivationBarImage.fillAmount = cv.Happiness;
		cvMotivationBarImage.sprite = (cv.Happiness >= 0.75f ? barGreenSprite : (cv.Happiness >= 0.5f ? barOrangeSprite : barRedSprite));
		ShowCV(true);
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

	private void UpdateProgressBar()
	{
		float fillAmount;
		if(GameMetaManager.DaysWithNegativeMoney > 0)
		{
			// Barra roja
			fillAmount = 0.5f - 0.5f * ((float)GameMetaManager.DaysWithNegativeMoney / (float)GameMetaManager.MaxDaysWithNegativeMoney);
		}
		else
		{
			fillAmount = 0.5f + 0.5f * ((float)Mathf.Clamp(GameMetaManager.Money.CurrentMoney, 0, float.MaxValue) / (float)GameMetaManager.Office.GetExpandTarget());
		}
		moneyProgressBarImage.fillAmount = fillAmount;
		moneyProgressBarImage.sprite = (fillAmount >= 0.75f ? barGreenSprite : (fillAmount >= 0.5f ? barOrangeSprite : barRedSprite));
	}

	private void ShowGameOverText(bool show)
	{
		gameOverLabelText.gameObject.SetActive(show);
	}

	private void ShowCV(bool show)
	{
		cvGameObject.SetActive(show);
	}
	
	[SerializeField]
	private Text moneyLabelText;
	
	[SerializeField]
	private Text daysPassedLabelText;

	[SerializeField]
	private GameObject daysWithNegativeMoneyTimerGameObject;
	[SerializeField]
	private Image moneyProgressBarImage;

	[SerializeField]
	private Button expandOfficeButton;

	[SerializeField]
	private Text gameOverLabelText;

	[SerializeField]
	private GameObject cvGameObject;
	[SerializeField]
	private Text cvNameText;
	[SerializeField]
	private Text cvMoneyText;
	[SerializeField]
	private Image cvMotivationBarImage;
	[SerializeField]
	private Button cvAcceptButton;
	[SerializeField]
	private Button cvRejectButton;

	[SerializeField]
	private Sprite barRedSprite;
	[SerializeField]
	private Sprite barOrangeSprite;
	[SerializeField]
	private Sprite barGreenSprite;

	private string cvText = "CV: {0}";
	private string moneyText = "$ {0}";
}

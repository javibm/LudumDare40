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
		gameOverPlayAgainButton.onClick.AddListener(OnGameOverPlayAgainButtonClick);
		gameOverTweetButton.onClick.AddListener(OnGameOverTweetButtonClick);
		gameOverMenuButton.onClick.AddListener(OnGameOverMenuButtonClick);
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
		GameMetaManager.OnUIButtonClicked();
		GameMetaManager.Office.TryExpand();
	}

	private void OnCVAcceptButtonClick()
	{
		GameMetaManager.OnUIButtonClicked();
		GameMetaManager.Employee.TryCreateNewEmployee(GameMetaManager.CVs.PendingCV.MoneyCost, GameMetaManager.CVs.PendingCV.Happiness);
		GameMetaManager.CVs.AcceptPendingCV();
		ShowCV(false);
	}
	private void OnCVRejectButtonClick()
	{
		GameMetaManager.OnUIButtonClicked();
		GameMetaManager.CVs.RejectPendingCV();
		ShowCV(false);
	}

	private void OnGameOverPlayAgainButtonClick()
	{
		GameMetaManager.OnUIButtonClicked();
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}
	
	private void OnGameOverTweetButtonClick()
	{
		GameMetaManager.OnUIButtonClicked();
		GetComponent<Twitter>().ShareToTW();
	}
	
	private void OnGameOverMenuButtonClick()
	{
		GameMetaManager.OnUIButtonClicked();
		// TODO
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
		cvMoneyText.text = string.Format(moneyText, cv.MoneyCost.ToString());
		cvMotivationBarImage.fillAmount = cv.Happiness;
		cvMotivationBarImage.sprite = (cv.Happiness >= 0.75f ? barGreenSprite : (cv.Happiness >= 0.5f ? barOrangeSprite : barRedSprite));
		ShowCV(true);
	}

	private void OnLoseGame()
	{
		ShowGameOverText(true);
		ShowCV(false);
		GameMetaManager.Time.OnDayPassed -= OnDayPassed;
	}
	
	private void UpdateMoney()
	{
		moneyLabelText.text = string.Format(moneyText, GameMetaManager.Money.CurrentMoney.ToString());
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
		moneyProgressBarImage.color = (fillAmount >= 0.75f ? barGreenColor : (fillAmount >= 0.5f ? barOrangeColor : barRedColor));
	}

	private void ShowGameOverText(bool show)
	{
		gameOverObject.SetActive(show);
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
	private GameObject gameOverObject;
	[SerializeField]
	private Button gameOverPlayAgainButton;
	[SerializeField]
	private Button gameOverTweetButton;
	[SerializeField]
	private Button gameOverMenuButton;

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

	[SerializeField]
	private Color barRedColor;
	[SerializeField]
	private Color barOrangeColor;
	[SerializeField]
	private Color barGreenColor;

	private string cvText = "CV: {0}";
	private string moneyText = "$ {0}";
}

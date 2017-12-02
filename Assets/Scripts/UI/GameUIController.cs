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

		UpdateMoney();
	}

	private void OnExpandOfficeButtonClick()
	{
		GameMetaManager.Office.TryExpand();
	}

	private void OnMoneyChanged()
	{
		UpdateMoney();
	}
	
	private void UpdateMoney()
	{
		moneyLabelText.text = GameMetaManager.Money.CurrentMoney.ToString();
	}
	
	[SerializeField]
	private Text moneyLabelText;

	[SerializeField]
	private Button expandOfficeButton;

}

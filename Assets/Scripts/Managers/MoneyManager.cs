using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager
{
	public int CurrentMoney
	{
		get;
		private set;
	}

	public event System.Action OnMoneyChanged;
	public event System.Action OnMoneyChangeToNegative;
	public event System.Action OnMoneyChangeToPositive;

	public MoneyManager(int initialMoney)
	{
		CurrentMoney = initialMoney;
	}

	public bool CanPay(int paymentQuantity)
	{
		// Permitimos dinero negativo!
		return true;
		// return CurrentMoney >= paymentQuantity;
	}

	public void AddMoney(int money)
	{
		int previousMoney = CurrentMoney;
		CurrentMoney += money;
		NotifyOnMoneyChanged();
		CheckNotifyMoneySignChange(previousMoney, CurrentMoney);
	}

	public void RemoveMoney(int money)
	{
		int previousMoney = CurrentMoney;
		CurrentMoney -= money;
		NotifyOnMoneyChanged();
		CheckNotifyMoneySignChange(previousMoney, CurrentMoney);
	}

	private void NotifyOnMoneyChanged()
	{
		if(OnMoneyChanged != null)
		{
			OnMoneyChanged();
		}
	}

	private void CheckNotifyMoneySignChange(int previous, int next)
	{
		if(previous < 0 && next > 0)
		{
			if(OnMoneyChangeToPositive != null)
			{
				OnMoneyChangeToPositive();
			}
		}
		else if(previous >= 0 && next < 0)
		{
			if(OnMoneyChangeToNegative != null)
			{
				OnMoneyChangeToNegative();
			}
		}
	}
}

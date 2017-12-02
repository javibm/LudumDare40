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

	public MoneyManager(int initialMoney)
	{
		CurrentMoney = initialMoney;
	}

	public bool CanPay(int paymentQuantity)
	{
		// TODO Si permitimos dinero negativo hacer siempre return true;
		return CurrentMoney >= paymentQuantity;
	}

	public void AddMoney(int money)
	{
		CurrentMoney += money;
	}

	public void RemoveMoney(int money)
	{
		CurrentMoney -= money;
	}
}

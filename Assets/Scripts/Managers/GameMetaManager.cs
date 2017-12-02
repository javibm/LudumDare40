using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMetaManager : Singleton<GameMetaManager> 
{
	public static OfficeManager Office
	{
		get
		{
			return Instance.office;
		}
	}

	public static MoneyManager Money
	{
		get
		{
			return Instance.money;
		}
	}

	protected new void Awake()
	{
		office = new OfficeManager(officeInitialSize);
		money = new MoneyManager(initialMoney);
	}

	private OfficeManager office;
	private MoneyManager money;

	[SerializeField]
	private int officeInitialSize = 2;
	[SerializeField]
	private int initialMoney = 1000;
}

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

	public static EmployeeManager Employee
	{
		get
		{
			return Instance.employees;
		}
	}

	public static TimeManager Time
	{
		get
		{
			return Instance.time;
		}
	}

	public static int DaysWithNegativeMoney
	{
		get
		{
			return Instance.consecutiveDaysWithNegativeMoney;
		}
	}

	public static int MaxDaysWithNegativeMoney
	{
		get
		{
			return Instance.gameStats.MaxDaysWithNegativeMoney;
		}
	}

	public static System.Action OnLoseGame;

	protected new void Awake()
	{
		base.Awake();
		office = new OfficeManager(gameStats.OfficeInitialSize, officeGenerator, officeStats);
		money = new MoneyManager(gameStats.InitialMoney);
		employees = new EmployeeManager(employeeGenerator);
		time = gameObject.GetComponent<TimeManager>();

		//TO DO INSTANCIACION DE PRUEBA
		employees.CreateNewEmployee(office.DeskList[0]);
	}

	void Start()
	{
		Money.OnMoneyChangeToNegative += OnMoneyChangeToNegative;
		Money.OnMoneyChangeToPositive += OnMoneyChangeToPositive;
		Time.OnDayPassed += OnDayPassed;
	}

	private void OnDayPassed()
	{
		if(Money.CurrentMoney < 0)
		{
			consecutiveDaysWithNegativeMoney++;
			if(consecutiveDaysWithNegativeMoney > gameStats.MaxDaysWithNegativeMoney)
			{
				NotifyOnLoseGame();
			}
		}
	}

	private void OnMoneyChangeToNegative()
	{
		
	}

	private void OnMoneyChangeToPositive()
	{
		consecutiveDaysWithNegativeMoney = 0;
	}

	private void NotifyOnLoseGame()
	{
		if(OnLoseGame != null)
		{
			OnLoseGame();
		}
	}

	private OfficeManager office;
	private MoneyManager money;
	private EmployeeManager employees;
	private TimeManager time;

	private int consecutiveDaysWithNegativeMoney;
	
	[SerializeField]
	private GameStats gameStats;
	[SerializeField]
	private OfficeGenerator officeGenerator;
	[SerializeField]
	private OfficeStats officeStats;
	[SerializeField]
	private EmployeeGenerator employeeGenerator;
}

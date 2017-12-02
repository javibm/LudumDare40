using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager
{
	public int CurrentSize
	{
		get;
		private set;
	}

	public OfficeManager(int initialSize)
	{
		CurrentSize = initialSize;
	}

	public int GetExpandCost()
	{
		return 1;	// TODO
	}

	public bool CanPayExpandCost()
	{
		return GameMetaManager.Money.CanPay(GetExpandCost());
	}

	public bool TryExpand()
	{
		if(CanPayExpandCost())
		{
			PayExpand();
			ExpandOffice();
			return true;
		}
		return false;
	}

	private void PayExpand()
	{
		GameMetaManager.Money.RemoveMoney(GetExpandCost());
	}

	private void ExpandOffice()
	{
		// TODO
	}
}


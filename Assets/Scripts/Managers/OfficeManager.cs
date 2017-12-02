using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeManager
{
	public int CurrentSize
	{
		get
		{
			return officeGenerator.CurrentSize;
		}
	}

	public List<OfficeDesk> DeskList
	{
		get
		{
			return officeGenerator.DeskList;
		}
	}

	public OfficeManager(int initialSize, OfficeGenerator officeGenerator, OfficeStats officeStats)
	{
		this.officeGenerator = officeGenerator;
		this.officeGenerator.InitOffice(initialSize);
		this.officeStats = officeStats;
	}

	public int GetExpandCost()
	{
		return officeStats.officeExpansionPrices[CurrentSize + 1];
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
		officeGenerator.ExpandOffice();
	}

	private OfficeGenerator officeGenerator = null;
	private OfficeStats officeStats = null;
}


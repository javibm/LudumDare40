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

	public List<OfficeDesk> DeskList
	{
		get
		{
			return officeGenerator.DeskList;
		}
	}

	public OfficeManager(int initialSize, OfficeGenerator officeGenerator)
	{
		CurrentSize = initialSize;
		this.officeGenerator = officeGenerator;
		this.officeGenerator.InitOffice(initialSize);
	}

	public int GetExpandCost()
	{
		return 100;	// TODO
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
}


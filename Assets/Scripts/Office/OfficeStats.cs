using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Office")]
public class OfficeStats : ScriptableObject 
{
	public List<int> officeExpansionPrices;
	public List<int> officeExpansionMoneyTarget;
	public List<int> officeDailyCost;
}

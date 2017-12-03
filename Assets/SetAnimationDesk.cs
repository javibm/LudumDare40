using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationDesk : MonoBehaviour {

	public void ActivateHolidayCartel(bool activate)
	{
		holidayCartel.SetActive(activate);
	}

	[SerializeField]
	private GameObject holidayCartel;
}

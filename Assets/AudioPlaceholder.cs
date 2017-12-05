using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlaceholder : MonoBehaviour {

	void Start () 
	{
		GameMetaManager.Employee.OnBackToWork += PlayBackToWork;
		GameMetaManager.Employee.OnEmployeeCreated += PlayDoor;
		GameMetaManager.Employee.OnAnswerCry += PlayCry;
		GameMetaManager.Employee.OnAnswerYay += PlayYay;
		GameMetaManager.CVs.OnNewCVGenerated += PlayCV;
		GameMetaManager.OnUIButtonClicked += PlayUI;
		GameMetaManager.Office.OnExpansion += PlayLevelUp;
		GameMetaManager.OnLoseGame += PlayGameOver;
		GameMetaManager.Employee.OnRageWindow += PlayRageWindow;
		GameMetaManager.Employee.OnRageDestroy += PlayRageDestroy;
		GameMetaManager.Employee.OnFired += PlayFired;
		GameMetaManager.Employee.OnPlane += PlayPlane;
		GameMetaManager.Employee.OnPayMoney += PlayPayMoney;
	}

	private void PlayDoor()
	{
	}

	private void PlayCV()
	{
	}

	private void PlayBackToWork()
	{
	}

	private void PlayCry()
	{
	}

	private void PlayYay()
	{
	}

	private void PlayUI()
	{
	}

	private void PlayLevelUp()
	{
	}

	private void PlayGameOver()
	{
	}

	private void PlayRageWindow()
	{
	}

	private void PlayRageDestroy()
	{
	}

	private void PlayFired()
	{
	}

	private void PlayPlane()
	{
	}

	private void PlayPayMoney()
	{
		
	}
}

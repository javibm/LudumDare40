using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour 
{
	void Awake()
	{
		officeGenerator.InitOffice(5);
	}

	void Start()
	{
	}

	[SerializeField]
	private OfficeGenerator officeGenerator;
}
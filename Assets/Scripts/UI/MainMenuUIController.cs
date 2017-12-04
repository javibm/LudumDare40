using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour 
{
	void Awake()
	{
    // Buttons listeners
		playButton.onClick.AddListener(OnPlayButtonClick);
		creditsButton.onClick.AddListener(OnCreditsButtonClick);
		creditsObject.SetActive(false);
	}
	
	void Start () 
	{
		// Eventos
	}

	private void OnPlayButtonClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
	
	private void OnCreditsButtonClick()
	{
		creditsObject.SetActive(true);

		List<string> teamNames = new List<string>();

		teamNames.Add("Carlota Esteban (Coding)\n@CarlotaEsCa");
		teamNames.Add("Javier Agüera (Coding)\n@AgueraJs");
		teamNames.Add("Marcos Díez (Coding)\n@Marcos10Tweets");
		teamNames.Add("Fran Martínez (GD, SFX)\n@pixfran");
		teamNames.Add("Miguel Martín (Art)\n@mmibarreta");
		teamNames.Add("Altea (Art)\n@askthegoat");
		
		for(int i = 0; i < creditLabelsList.Count; i++)
		{
			int next = Random.Range(0, teamNames.Count);
			creditLabelsList[i].text = teamNames[next];
			teamNames.RemoveAt(next);
		}
	}
	
	[SerializeField]
	private Button playButton;
	[SerializeField]
	private Button creditsButton;
	[SerializeField]
	private GameObject creditsObject;
	[SerializeField]
	private List<Text> creditLabelsList;
}

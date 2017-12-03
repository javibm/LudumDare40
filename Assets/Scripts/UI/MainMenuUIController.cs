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
	}
	
	void Start () 
	{
		// Eventos
	}

	private void OnPlayButtonClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	}
	
	private void OnCreditsButtonClick()
	{
	
	}
	
	[SerializeField]
	private Button playButton;
	[SerializeField]
	private Button creditsButton;
}

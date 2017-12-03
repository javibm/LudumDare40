using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	[System.Serializable]
	public struct AudioStruct
	{
		public AudioType audioType;
		public AudioSource[] audioClips;
	}

	public enum AudioType
	{
		Default,
		Main,
		Gameover,
		Loop,
		Door,
		CV,
		Typing,
		BackToWork,
		Cry,
		Yay,
		UI,
		LevelUp,
		RageWindow,
		RageDestroy,
		Fired,
		Plane
	}

	void Start ()
	{
		// DontDestroyOnLoad (gameObject);
		// PlaySound (AudioType.Main);
		PlaySound(AudioType.Loop, true);
		PlaySound(AudioType.Typing, true);
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
	}

	private void PlaySound (AudioType audioType, bool loop = false)
	{
		if (!_audios [(int)audioType].audioClips [0].isPlaying) {
			_audios [(int)audioType].audioClips [0].loop = loop;
			_audios [(int)audioType].audioClips [0].Play ();	
		}			
	}

	private void OnAnimationStart ()
	{
		PlaySound (AudioType.Loop);
	}

	private void PlayDoor()
	{
		PlaySound (AudioType.Door);
	}

	private void PlayCV()
	{
		PlaySound (AudioType.CV);
	}

	private void PlayBackToWork()
	{
		PlaySound (AudioType.BackToWork);
	}

	private void PlayCry()
	{
		PlaySound (AudioType.Cry);
	}

	private void PlayYay()
	{
		PlaySound (AudioType.Yay);
	}

	private void PlayUI()
	{
		PlaySound (AudioType.UI);
	}

	private void PlayLevelUp()
	{
		PlaySound (AudioType.LevelUp);
	}

	private void PlayGameOver()
	{
		PlaySound (AudioType.Gameover);
	}

	private void PlayRageWindow()
	{
		PlaySound (AudioType.RageWindow);
	}

	private void PlayRageDestroy()
	{
		PlaySound (AudioType.RageDestroy);
	}

	private void PlayFired()
	{
		PlaySound (AudioType.Fired);
	}

	private void PlayPlane()
	{
		PlaySound (AudioType.Plane);
	}

  	[SerializeField]
	private AudioStruct[] _audios;

}
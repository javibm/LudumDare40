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
		Yay
	}

	void Start ()
	{
		// DontDestroyOnLoad (gameObject);
		// PlaySound (AudioType.Main);
		PlaySound(AudioType.Loop);
		PlaySound(AudioType.Typing);
		GameMetaManager.Employee.OnBackToWork += PlayBackToWork;
		GameMetaManager.Employee.OnEmployeeCreated += PlayDoor;
		GameMetaManager.Employee.OnAnswerCry += PlayCry;
		GameMetaManager.Employee.OnAnswerYay += PlayYay;
		GameMetaManager.CVs.OnNewCVGenerated += PlayCV;
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

  [SerializeField]
	private AudioStruct[] _audios;

}
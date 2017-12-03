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
		Loop
	}


	void Awake ()
	{
		// DontDestroyOnLoad (gameObject);
		// PlaySound (AudioType.Main);
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

  [SerializeField]
	private AudioStruct[] _audios;

}
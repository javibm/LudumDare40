using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullifyRotation : MonoBehaviour {

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		transformCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;

	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		transform.LookAt(transformCamera);
		transform.Rotate(0, 180, 0);
	}

	private Transform transformCamera;
	private RectTransform rectTransform;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour 
{
	public Camera Camera
	{
		get
		{
			return mainCamera;
		}
	}

	public void Init()
	{
		GameMetaManager.Office.OnExpansion += OnOfficeExpansion;
		CenterCamOnOffice(false);
	}

	private void OnOfficeExpansion()
	{
		CenterCamOnOffice(true);
	}

	public void CenterCamOnOffice(bool animate)
	{
		if(centerCamOffetCoroutine != null)
		{
			StopCoroutine(centerCamOffetCoroutine);
		} 
		centerCamOffetCoroutine = StartCoroutine(centerCamOffsetAnimator(animate ? duration : 0));
	}	

	private IEnumerator centerCamOffsetAnimator(float duration)
	{
		int size = GameMetaManager.Office.CurrentSize;
		Vector3 iniPos = cameraPivot.localPosition;
		Vector3 endPos = new Vector3(size / 2f, 0f, size/2f);
		float iniSize = mainCamera.orthographicSize;
		float endSize = size / 2f;

		SetCameraIterp(iniPos, endPos, iniSize, endSize, 0);
		yield return new WaitForSeconds(startDelay);
		float currentTime = 0;
		while (currentTime < duration)
		{
			SetCameraIterp(iniPos, endPos, iniSize, endSize, currentTime / duration);
			currentTime += Time.deltaTime;
			yield return null;
		}
		SetCameraIterp(iniPos, endPos, iniSize, endSize, 1);
	}

	private void SetCameraIterp(Vector3 iniPos, Vector3 endPos, float iniSize, float endSize, float t)
	{
		cameraPivot.localPosition = (iniPos + (endPos - iniPos) * positionCurve.Evaluate(t));
		mainCamera.orthographicSize = (iniSize + (endSize - iniSize) * sizeCurve.Evaluate(t));
	}

	private Coroutine centerCamOffetCoroutine = null;

	[SerializeField]
	private Camera mainCamera;
	[SerializeField]
	private Transform cameraPivot;
	[SerializeField]
	private AnimationCurve positionCurve;
	[SerializeField]
	private AnimationCurve sizeCurve;
	[SerializeField]
	private float startDelay;
	[SerializeField]
	private float duration;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeParticlesController : MonoBehaviour 
{
	public void PlayDestroyComputerParticles()
	{
		if(destroyComputerParticles != null)
		{
			destroyComputerParticles.Play();
		}
	}

	public void PlayWindowParticles()
	{
		if(windowParticles != null)
		{
			windowParticles.SetActive(true);
		}
	}
	[SerializeField]
	private ParticleSystem destroyComputerParticles;

	[SerializeField]
	private GameObject windowParticles;
}

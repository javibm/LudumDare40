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
	[SerializeField]
	private ParticleSystem destroyComputerParticles;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
  public NavigationBaker navBaker;
  public List<UnityEngine.AI.NavMeshSurface> surfaces;

	// Use this for initialization
	void Start ()
  {
    navBaker.BakeNavMesh(surfaces);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

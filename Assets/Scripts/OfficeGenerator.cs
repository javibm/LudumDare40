using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OfficeGenerator : MonoBehaviour 
{
	public List<OfficeDesk> DeskList
	{
		get
		{
			return deskList;
		}
	}

	public void ExpandOffice()
	{
		Debug.Log("Expanding Office");
		officeCurrentStep++;
		generateOfficeStep(officeCurrentStep);
	}

	void Awake()
	{
		deskList = new List<OfficeDesk>();
		officeCurrentStep = 1;
		generateInitialOffice();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ExpandOffice();
		}	
	}

	private void generateInitialOffice()
	{
		transform.localPosition = Vector3.zero;
    generateOfficeStep(officeCurrentStep);
	}

	private void generateOfficeStep(int step)
	{
		GameObject go;
		// Floor generation
		for(int i = 0; i < step; ++i)
		{
			go = Instantiate(floorPrefab);
			go.transform.SetParent(transform);
			go.transform.localPosition = new Vector3(cellSize * i, 0f, cellSize * (step-1));
      if (step == 1)
      {
        navMeshSurface = go.GetComponentInChildren<NavMeshSurface>();
      }
      if (i < step-1)
			{
				go = Instantiate(floorPrefab);
				go.transform.SetParent(transform);
				go.transform.localPosition = new Vector3(cellSize * (step-1), 0f, cellSize * i);
			}
		}

		// Wall generation
		go = Instantiate(wallPrefab);
		go.transform.SetParent(transform);
		go.transform.localPosition = new Vector3(cellSize * (step-1), 0f, 0f);
		go.transform.eulerAngles = new Vector3(0f, -90, 0f);

		go = Instantiate(wallPrefab);
		go.transform.SetParent(transform);
		go.transform.localPosition = new Vector3(0f, 0f, cellSize * (step-1));
		go.transform.eulerAngles = new Vector3(0f, 0, 0f);

		// Desk generation
		OfficeDesk desk;
		for(int i = 0; i < step; ++i)
		{
			desk = Instantiate(deskPrefab);
			desk.transform.SetParent(transform);
			desk.transform.localPosition = new Vector3(cellSize * i, 0f, cellSize * (step-1));
			deskList.Add(desk);

			if(i < step-1)
			{
				desk = Instantiate(deskPrefab);
				desk.transform.SetParent(transform);
				desk.transform.localPosition = new Vector3(cellSize * (step-1), 0f, cellSize * i);
				deskList.Add(desk);
			}
		}
		// NavMesh Regeneration
		if(navigationBaker != null)
		{
			navigationBaker.BakeNavMesh(navMeshSurface);
		}
	}

	private int officeCurrentStep = 0;
	
	[SerializeField]
	private float cellSize = 1f;

	[SerializeField]
	private GameObject floorPrefab;
	[SerializeField]
	private OfficeDesk deskPrefab;
	[SerializeField]
	private GameObject wallPrefab;

	[SerializeField]
	private NavigationBaker navigationBaker;

	private NavMeshSurface navMeshSurface;
	private List<OfficeDesk> deskList;
}

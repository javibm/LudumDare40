using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OfficeGenerator : MonoBehaviour 
{
	public List<Transform> DeskTransformList
	{
		get
		{
			return deskTransformList;
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
		navMeshSurfaceList = new List<NavMeshSurface>();
		deskTransformList = new List<Transform>();
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
		officeRoot = new GameObject();
		officeRoot.name = "OfficeRoot";
		officeRootTransform = officeRoot.transform;
		officeRootTransform.localPosition = Vector3.zero;

		generateOfficeStep(officeCurrentStep);
	}

	private void generateOfficeStep(int step)
	{
		GameObject go;
		// Floor generation
		for(int i = 0; i < step; ++i)
		{
			go = Instantiate(floorPrefab);
			go.transform.SetParent(officeRootTransform);
			go.transform.localPosition = new Vector3(cellSize * i, 0f, cellSize * (step-1));
			navMeshSurfaceList.Add(go.GetComponent<NavMeshSurface>());

			if(i < step-1)
			{
				go = Instantiate(floorPrefab);
				go.transform.SetParent(officeRootTransform);
				go.transform.localPosition = new Vector3(cellSize * (step-1), 0f, cellSize * i);
				navMeshSurfaceList.Add(go.GetComponent<NavMeshSurface>());
			}
		}

		// Wall generation
		go = Instantiate(wallPrefab);
		go.transform.SetParent(officeRootTransform);
		go.transform.localPosition = new Vector3(cellSize * (step-1), 0f, 0f);
		go.transform.eulerAngles = new Vector3(0f, -90, 0f);

		go = Instantiate(wallPrefab);
		go.transform.SetParent(officeRootTransform);
		go.transform.localPosition = new Vector3(0f, 0f, cellSize * (step-1));
		go.transform.eulerAngles = new Vector3(0f, 0, 0f);

		// Desk generation
		for(int i = 0; i < step; ++i)
		{
			go = Instantiate(deskPrefab);
			go.transform.SetParent(officeRootTransform);
			go.transform.localPosition = new Vector3(cellSize * i, 0f, cellSize * (step-1));
			deskTransformList.Add(go.transform);

			if(i < step-1)
			{
				go = Instantiate(deskPrefab);
				go.transform.SetParent(officeRootTransform);
				go.transform.localPosition = new Vector3(cellSize * (step-1), 0f, cellSize * i);
				deskTransformList.Add(go.transform);
			}
		}
		// NavMesh Regeneration
		navigationBaker.BakeNavMesh(navMeshSurfaceList);
	}

	private int officeCurrentStep = 0;
	
	private GameObject officeRoot;
	private Transform officeRootTransform;
	
	[SerializeField]
	private float cellSize = 1f;

	[SerializeField]
	private GameObject floorPrefab;
	[SerializeField]
	private GameObject deskPrefab;
	[SerializeField]
	private GameObject wallPrefab;

	[SerializeField]
	private NavigationBaker navigationBaker;

	private List<NavMeshSurface> navMeshSurfaceList;
	private List<Transform> deskTransformList;
}

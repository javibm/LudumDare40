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

  public List<IdlePoint> IdleList
  {
    get
    {
      return idleList;
    }
  }

  public int CurrentSize
	{
		get;
		private set;
	}

	public void InitOffice(int initialSize)
	{
		for(int i = 1; i <= initialSize; ++i)
		{
			ExpandOffice();
		}
	}

	public void ExpandOffice()
	{
		CurrentSize++;
		generateOfficeStep(CurrentSize);
	}

	void Awake()
	{
		deskList = new List<OfficeDesk>();
    idleList = new List<IdlePoint>();
    CurrentSize = 0;
	}

  private void generateOfficeStep(int step)
  {
    GameObject go;
    // Floor generation
    for (int i = 0; i < step; ++i)
    {
      if (step == 1)
      {
        go = Instantiate(bossPrefab);
        go.transform.SetParent(transform);
        go.transform.localRotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        go.transform.localPosition = new Vector3(cellSize * i, 0f, cellSize * (step - 1));
      }
      else
      {
        go = Instantiate(floorPrefab);
        go.transform.SetParent(transform);
        go.transform.localPosition = new Vector3(cellSize * i, 0f, cellSize * (step - 1));
      }
      if (step == 2)
      {
        navMeshSurface = go.GetComponentInChildren<NavMeshSurface>();
      }
      if (i < step - 1)
      {
        go = Instantiate(floorPrefab);
        go.transform.SetParent(transform);
        go.transform.localPosition = new Vector3(cellSize * (step - 1), 0f, cellSize * i);
      }
    }

    if (step > 1)
    {
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
        idleList.Add(desk.GetComponentInChildren<IdlePoint>());
        if (i < step-1)
			  {
				  desk = Instantiate(deskPrefab);
				  desk.transform.SetParent(transform);
				  desk.transform.localPosition = new Vector3(cellSize * (step-1), 0f, cellSize * i);
				  deskList.Add(desk);
          idleList.Add(desk.GetComponentInChildren<IdlePoint>());
			  }
    }
    if (navMeshSurface != null)
    {
      NavigationBaker.BakeNavMesh(navMeshSurface);
    }
		}
	}
	
	[SerializeField]
	private float cellSize = 1f;

	[SerializeField]
	private GameObject floorPrefab;
	[SerializeField]
	private OfficeDesk deskPrefab;
	[SerializeField]
	private GameObject wallPrefab;
  [SerializeField]
  private GameObject bossPrefab;

	private NavMeshSurface navMeshSurface;
	private List<OfficeDesk> deskList;
  private List<IdlePoint> idleList;
}

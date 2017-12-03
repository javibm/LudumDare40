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
        go.transform.localPosition = new Vector3(cellSize * i, 0.1f, cellSize * (step - 1));
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
      go = Instantiate((step % 2 == 0) ? wallPrefab : wallWindowPrefab);
      go.transform.SetParent(transform);
      go.transform.localPosition = new Vector3(cellSize * (step - 1), 0f, 0f);
      go.transform.eulerAngles = new Vector3(0f, -90, 0f);

      go = Instantiate((step % 2 != 0) ? wallPrefab : wallWindowPrefab);
      go.transform.SetParent(transform);
      go.transform.localPosition = new Vector3(0f, 0f, cellSize * (step - 1));
      go.transform.eulerAngles = new Vector3(0f, 0, 0f);

      // Idle places generation
      if(step % 2 == 0)
      {
        go = Instantiate(getNextIdleObject());
        go.transform.SetParent(transform);
        go.transform.localPosition = new Vector3(cellSize * (step - 1), 0f, 0f);
        go.transform.eulerAngles = new Vector3(0f, -90, 0f);
        idleList.Add(go.GetComponentInChildren<IdlePoint>());
      }
      else
      {
        go = Instantiate(getNextIdleObject());
        go.transform.SetParent(transform);
        go.transform.localPosition = new Vector3(0f, 0f, cellSize * (step - 1));
        go.transform.eulerAngles = new Vector3(0f, 0, 0f);
        idleList.Add(go.GetComponentInChildren<IdlePoint>());
      }

		  // Desk generation
		  OfficeDesk desk;
		  for(int i = 1; i < step; ++i)
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

  private int idleObjectCount = -1;
  private GameObject getNextIdleObject()
  {
    // TODO: random o no?
    //int offset = Random.Range(-1f, 1f) > 0 ? 1 : 2;
    int offset = 1;
    idleObjectCount = (idleObjectCount + offset) % idlePrefabs.Length;
    return idlePrefabs[idleObjectCount];
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
  private GameObject wallWindowPrefab;
  [SerializeField]
  private GameObject bossPrefab;
  [SerializeField]
  private GameObject[] idlePrefabs;

	private NavMeshSurface navMeshSurface;
	private List<OfficeDesk> deskList;
  private List<IdlePoint> idleList;
}

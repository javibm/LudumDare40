// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{

  public List<Transform> PointsList;
  private int destPointIndex = 0;
  private NavMeshAgent agent;
  private float timeElapsed;
  private Transform currentPoint;

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = false;
    timeElapsed = 0.0f;
    setRandomSpeed();
    GotoNextPoint();
  }

  void Update()
  {
    if ((!agent.pathPending && agent.remainingDistance < 0.3f) || agent.isStopped )
    {
      timeElapsed += Time.deltaTime;
      agent.isStopped = true;
      if (timeElapsed > Random.Range(1f, 5f))
      {
        timeElapsed = 0.0f;
        GotoNextPoint();
      }
    }
  }

  private void GotoNextPoint()
  {
    if (PointsList.Count == 0)
    {
      return;
    }

    agent.isStopped = false;
    setRandomSpeed();

    if (currentPoint != null)
    {
      PointsList.Add(currentPoint);
    }
    destPointIndex = Random.Range(0, PointsList.Count);
    currentPoint = PointsList[destPointIndex];
    agent.destination = PointsList[destPointIndex].position;
    PointsList.Remove(PointsList[destPointIndex]);
  }

  private void setRandomSpeed()
  {
    agent.speed = Random.Range(2f, 5f);
  }
}
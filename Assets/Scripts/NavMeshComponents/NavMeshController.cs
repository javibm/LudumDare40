using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NavMeshController : MonoBehaviour
{

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = true;
  }

  void Update()
  {
    if ((!agent.pathPending && agent.remainingDistance < 0.1f) || agent.isStopped)
    {
      agent.isStopped = true;
      if (NavigateFinishedCallback != null)
      {
        NavigateFinishedCallback();
      }
    }
  }

  public void NavigateTo(Transform target, float speed, OnNavigateFinished del)
  {
    agent.isStopped = false;
    agent.speed = speed;
    agent.destination = target.position;
    NavigateFinishedCallback = del;
  }

  private NavMeshAgent agent;
  public delegate void OnNavigateFinished();
  public OnNavigateFinished NavigateFinishedCallback;

}
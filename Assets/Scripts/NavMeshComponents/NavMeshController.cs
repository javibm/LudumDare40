using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshController : MonoBehaviour
{

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.autoBraking = true;
  }

  void Update()
  {
    if ((!agent.pathPending && agent.remainingDistance < 0.1f && target != null) || agent.isStopped)
    {
      agent.isStopped = true;
      var lookPos = target.position - transform.position;
      lookPos.y = 0;
      var rotation = Quaternion.LookRotation(lookPos);
      transform.rotation = rotation;
      transform.position = target.position;

      if (NavigateFinishedCallback != null)
      {
        NavigateFinishedCallback();
      }
    }
  }

  public void NavigateTo(Transform target, float speed, OnNavigateFinished del)
  {
    this.target = target;
    agent.isStopped = false;
    agent.speed = speed;
    agent.destination = target.position;
    NavigateFinishedCallback = del;
  }

  private float time = 2.0f;
  private float elapsedTime;
  private Transform target;
  private NavMeshAgent agent;
  public delegate void OnNavigateFinished();
  public OnNavigateFinished NavigateFinishedCallback;

}
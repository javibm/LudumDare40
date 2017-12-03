using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshController : MonoBehaviour
{

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
  }

  void Update()
  {
    if (target != null)
    {
      Quaternion newRotation = Quaternion.LookRotation(target.position - transform.position);
      newRotation.x = 0f;
      newRotation.z = 0f;
      transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10f);
    }

    if ((!agent.pathPending && agent.remainingDistance < 0.2f && target != null) || agent.isStopped)
    {
      agent.isStopped = true;
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

  private Transform target;
  private NavMeshAgent agent;
  public delegate void OnNavigateFinished();
  public OnNavigateFinished NavigateFinishedCallback;

}
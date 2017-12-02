using UnityEngine;

public class EmployeeAnimationController : MonoBehaviour
{

  void Awake()
  {
    animatorController.GetComponent<Animator>();
  }

  public void WalkAnim()
  {
    animatorController.CrossFade("Walking", 0.0f);
  }

  public void IdleAnim()
  {
    animatorController.CrossFade("Idle", 0.0f);
  }

  public void WorkAnim()
  {
    animatorController.CrossFade("Work", 0.0f);
  }

  private Animator animatorController;	
}

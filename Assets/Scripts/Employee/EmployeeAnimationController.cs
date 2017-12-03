using UnityEngine;

public class EmployeeAnimationController : MonoBehaviour
{
  void Start()
  {
    animatorController = GetComponent<Animator>();
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
    animatorController.CrossFade("Working", 0.0f);
  }

  public void JumpAnim()
  {
    animatorController.CrossFade("Jump", 0.0f);
  }

  public void DestroyAnim()
  {
    animatorController.CrossFade("Destroy", 0.0f);
  }

  public void RunAnim()
  {
    animatorController.CrossFade("Run", 0.0f);
  }

  private Animator animatorController;	
}

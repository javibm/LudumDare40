using UnityEngine;

public class EmployeeAnimationController : MonoBehaviour
{
  void Start()
  {
    animatorController = GetComponent<Animator>();
  }

  public void WalkAnim()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Walking", 0.0f);
    }
  }

  public void IdleAnim()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Idle", 0.0f);
    }
  }

  public void IdleAnim2()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Idle2", 0.0f);
    }
  }

  public void IdleAnim3()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Idle3", 0.0f);
    }
  }

  public void WorkAnim()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Working", 0.0f);
    }
  }

  public void JumpAnim()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Jump", 0.0f);
    }
  }

  public void DestroyAnim()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Destroy", 0.0f);
    }
  }

  public void RunAnim()
  {
    if(animatorController != null)
    {
      animatorController.CrossFade("Run", 0.0f);
    }
  }

  private Animator animatorController;	
}

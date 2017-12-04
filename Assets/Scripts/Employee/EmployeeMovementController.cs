using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeMovementController : MonoBehaviour {

  public Transform Target
  {
    get;
    private set;
  }

  public float Speed
  {
    get;
    set;
  }

  public void Init(OfficeDesk officeDesk, NavMeshController navMeshController, EmployeeAnimationController animController, EmployeeParticlesController particlesController)
  {
    personalOfficeDesk = officeDesk;
    personalOfficeDesk.Filled = true;

    this.navMeshController = navMeshController;
    this.animController = animController;
    this.particlesController = particlesController;

    Speed = 1;
  }

  public void MoveToProcrastinationTarget()
  {
    if (Target == personalOfficeDesk.Transform)
    {
      selectNewTarget();
      float randomFloat = Random.Range(0.0f, 1.0f);
      if(randomFloat > 0.0f && randomFloat < 0.35f)
      {
        navigate(Idle);
      }
      else if(randomFloat > 0.35f && randomFloat < 0.75f)
      {
        navigate(Idle2);
      }
      else
      {
        navigate(Idle3);
      }
    }
  }

  public void MoveToCrazyTarget(bool isDestroy)
  {
    if(isDestroy)
    {
      GoToDestroy();
    }
    else
    {
      GoToWindow();
    }
  }

  public void GoToRandom()
  {
    selectNewTarget();
    navigate(GoToRandom);
  }

  public void MoveToDesk()
  {
    if (Target != personalOfficeDesk.Transform)
    {
      Target = personalOfficeDesk.Transform;
      navigate(Work);
    }
  }

  public void GoToWindow()
  {
    if (Target == personalOfficeDesk.Transform)
    {
      windowPoint = GameMetaManager.Office.GetRandomWindow();
      Target = windowPoint.transform;
      GameMetaManager.Employee.OnEmployeeWindow(windowPoint);
      personalOfficeDesk.Filled = false;
      navigate(JumpAnim);
      selectNewTarget();      
    }
  }

  public void GoToDestroy()
  {
    if (Target == personalOfficeDesk.Transform)
    {
      GameMetaManager.Employee.OnRageDestroy();     
      navigate(DestroyAnim);
      selectNewTarget();      
    }
  }

  public void Work()
  {
    animController.WorkAnim();
  }

  public void Idle()
  {
    animController.IdleAnim();
  }

  public void Idle2()
  {
    animController.IdleAnim2();
  }

  public void Idle3()
  {
    animController.IdleAnim3();
  }

  public void DestroyAnim()
  {
    animController.DestroyAnim();
    particlesController.PlayDestroyComputerParticles();
  }

  public void JumpAnim()
  {
    animController.JumpAnim();
    GameMetaManager.Employee.OnEmployeeClosed(windowPoint);
  }

  public void ReleaseDesk()
  {
    personalOfficeDesk.Filled = false;
  }

  private void selectNewTarget()
  {
    Target = GameMetaManager.Office.GetRandomIdle().transform;
  }

  private void navigate(NavMeshController.OnNavigateFinished del)
  {
    navMeshController.NavigateTo(Target, Speed, del);
    animController.WalkAnim();
  }

  private OfficeDesk personalOfficeDesk;
  private NavMeshController navMeshController;
  private EmployeeAnimationController animController;

  private EmployeeParticlesController particlesController;

  private WindowPoint windowPoint;

}

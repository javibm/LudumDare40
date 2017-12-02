using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
  public void BakeNavMesh(NavMeshSurface surface)
  {
    surface.BuildNavMesh();
  }
}

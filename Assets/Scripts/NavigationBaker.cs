using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{
  public void BakeNavMesh(List<NavMeshSurface> surfaces)
  {
    surfaces[0].BuildNavMesh();
    //foreach (var surface in surfaces)
    //{
    //  surface.BuildNavMesh();
    //}
  }
}

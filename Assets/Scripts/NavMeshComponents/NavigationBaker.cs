using UnityEngine.AI;

public static class NavigationBaker
{
  public static void BakeNavMesh(NavMeshSurface surface)
  {
    surface.BuildNavMesh();
  }
}

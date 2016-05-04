using UnityEngine;
using System.Collections;

public static class Util{
  public static void ComputeResponsiveScreenPoints(Camera camera, out Vector3 leftBottom, out Vector3 rightTop){
    Vector3 lb_position = Vector3.zero;
    Vector3 rt_position = Vector3.zero;

    rt_position.x = camera.pixelWidth;
    rt_position.y = camera.pixelHeight;
    rt_position.z = 0;

    leftBottom = camera.ScreenToWorldPoint(lb_position);
    rightTop = camera.ScreenToWorldPoint(rt_position);
  }

  public static GameObject LoadPFab(string ruta){
    return GameObject.Instantiate(Resources.Load<GameObject>(ruta));
  }
}

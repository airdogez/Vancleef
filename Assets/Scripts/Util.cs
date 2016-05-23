using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


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

  public static GameObject GetNestedGameObjects(GameObject parent, string name)
  {
    GameObject result = parent;
    List<GameObject> pendingGO = new List<GameObject>();

    pendingGO.Add(parent);

    while (pendingGO.Count > 0)
    {
      GameObject analizeGO = pendingGO[0];
      pendingGO.RemoveAt(0);

      for (int i = 0; i < analizeGO.transform.childCount; i++)
      {
        GameObject go = analizeGO.transform.GetChild(i).gameObject;

        if (go.name == name)
        {
          result = go;
          break;
        }
        else if (go.transform.childCount > 0)
        {
          pendingGO.Add(go);
        }
      }
      if (result != null)
      {
        break;
      }
    }
    return result;
  }

  public static Dictionary<string, object> ParseScript(string script) {
    Dictionary<string, object> result = new Dictionary<string, object> ();

    string[] prop = script.Split (';');

    for (int i = 0; i < prop.Length; i++) {
      string[] objValue = prop [i].Split(':');

      string key = objValue [0];
      float resFloat = 0;
      bool resBool = false;

      if (float.TryParse (objValue [1], out resFloat)) {
        result[key] = resFloat;
      }
      else if (bool.TryParse (objValue [1], out resBool)) {
        result[key] = resBool;
      }
      else {
        result[key] = objValue [1];
      }
    }

    return result;
  }

}

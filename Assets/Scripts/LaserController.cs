using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    Vector3 pos = gameObject.transform.localPosition;
    pos.y += 0.5f;
    gameObject.transform.localPosition = pos;

  }
}

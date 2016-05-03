using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");

    Vector3 pos = gameObject.transform.localPosition;
    pos.x += x/10f;
    pos.y += y/12f;
    gameObject.transform.localPosition = pos;

  }
}

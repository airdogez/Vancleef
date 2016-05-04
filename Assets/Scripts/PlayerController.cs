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
    bool shift = Input.GetButton("Slow Down");
    float mod = (shift) ? 10f : 5f;
    Vector3 pos = gameObject.transform.localPosition;
    pos.x += x/mod;
    pos.y += y/mod;
    gameObject.transform.localPosition = pos;
  }
}

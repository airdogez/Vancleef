using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour {

  // Use this for initialization
  void Start () {
    //Set initial position of player 
    Vector3 leftBottom = Vector3.zero;
    Vector3 rightTop = Vector3.zero;
    Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);

    Vector3 pos = gameObject.transform.localPosition;

    pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, 0.5f);
    pos.y = Mathf.Lerp(rightTop.y, leftBottom.y, 0.85f);

    gameObject.transform.localPosition = pos;

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

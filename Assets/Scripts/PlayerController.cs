using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

  private Vector3 leftBottom;
  private Vector3 rightTop;

  public GameObject bulletPrefab;
  public float speed;
  public float shootDelay;

  void Start () {
    //Set initial position of player 
    leftBottom = Vector3.zero;
    rightTop = Vector3.zero;
    Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);

    Vector3 pos = gameObject.transform.localPosition;

    pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, 0.5f);

    pos.y = Mathf.Lerp(rightTop.y, leftBottom.y, 0.85f);

    gameObject.transform.localPosition = pos;;

  }

  void Update () {
    //Movement
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");
    bool shift = Input.GetButton("Slow Down");
    float mod = (shift) ? 5f : 10f;
    Vector3 pos = gameObject.transform.localPosition;
    pos.x += x * mod * Time.deltaTime;
    pos.y += y * mod * Time.deltaTime;

    Bounds bounds = GetComponent<SpriteRenderer>().bounds;
    float width = bounds.extents.x / 2f;
    float height = bounds.extents.y / 2;

    if (pos.x+width > rightTop.x)
      pos.x = rightTop.x-width;
    if (pos.x < leftBottom.x + width)
      pos.x =leftBottom.x+width;

    if (pos.y+height > rightTop.y)
      pos.y = rightTop.y-height;
    if (pos.y < leftBottom.y +width)
      pos.y =leftBottom.y+height;

    gameObject.transform.localPosition = pos;

    //Shoot Bullets
    if (Input.GetButtonDown("Primary Fire")) 
      StartCoroutine (Shoot ());
  }

  IEnumerator Shoot()
  {
    while (Input.GetButton("Primary Fire")) {
      yield return new WaitForSeconds (shootDelay);
      GameObject go = (GameObject) Instantiate (bulletPrefab, transform.position, transform.rotation);
    }
  }

}

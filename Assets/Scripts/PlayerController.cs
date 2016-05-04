using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

  private const int NUMBER_BULLETS = 10;

  private List<GameObject> bullets;
  private int currentBullet;
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
    

    //Create reusable bullets
    bullets = new List<GameObject>();
    for (int i = 0; i < NUMBER_BULLETS; i++)
    {
      GameObject bullet = Util.LoadPFab("Prefabs/prefab_basic_bullet");
      bullet.active = false;
      bullets.Add(bullet);
    }
    currentBullet = 0;

  }

  // Update is called once per frame
  void Update () {
    //Movement
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");
    bool shift = Input.GetButton("Slow Down");
    float mod = (shift) ? 10f : 5f;
    Vector3 pos = gameObject.transform.localPosition;
    pos.x += x/mod;
    pos.y += y/mod;
    gameObject.transform.localPosition = pos;

    //Shoot Bullets
    //Set initial position and activate
    if (currentBullet >= NUMBER_BULLETS)
      currentBullet = 0;
    if (Input.GetButtonDown("Primary Fire")) {
      GameObject bullet = bullets[currentBullet++];
      Vector3 bullet_position = bullet.transform.localPosition;
      bullet_position.x = transform.localPosition.x;
      bullet_position.y = transform.localPosition.y;
      bullet.transform.localPosition = pos;
      bullet.active = true;
    }
  }
}

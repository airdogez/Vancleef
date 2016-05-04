using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

  private const int NUMBER_BULLETS = 3;

  private List<GameObject> bullets;
  private int currentBullet;
  private Vector3 leftBottom;
  private Vector3 rightTop;
  private float primaryCooldown;
  // Use this for initialization
  void Start () {
    //Set initial position of player 
    leftBottom = Vector3.zero;
    rightTop = Vector3.zero;
    Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);

    Vector3 pos = gameObject.transform.localPosition;

    pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, 0.5f);

    pos.y = Mathf.Lerp(rightTop.y, leftBottom.y, 0.85f);

    gameObject.transform.localPosition = pos;;
    primaryCooldown = 10f;
    

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
    float mod = (shift) ? 5f : 10f;
    Vector3 pos = gameObject.transform.localPosition;
    pos.x += x * mod * Time.deltaTime;
    pos.y += y * mod * Time.deltaTime;

    if (pos.x > rightTop.x)
      pos.x = rightTop.x;
    if (pos.x < leftBottom.x)
      pos.x =leftBottom.x;

    if (pos.y > rightTop.y)
      pos.y = rightTop.y;
    if (pos.y < leftBottom.y)
      pos.y =leftBottom.y;

    gameObject.transform.localPosition = pos;

    //Shoot Bullets
    //Set initial position and activate
    if (currentBullet >= NUMBER_BULLETS)
      currentBullet = 0;
    if (Input.GetButtonDown("Primary Fire")) {
      GameObject bullet = bullets[currentBullet++];
      if (!bullet.active){
        Vector3 bullet_position = bullet.transform.localPosition;
        bullet_position.x = transform.localPosition.x;
        bullet_position.y = transform.localPosition.y;
        bullet.transform.localPosition = pos;
        bullet.active = true;
      }
    }
    //If bullet is outside disabled it
    foreach (var bullet in bullets)
    {
      if(bullet.transform.localPosition.y > rightTop.y){
        bullet.active = false;
      }
    }
  }
}

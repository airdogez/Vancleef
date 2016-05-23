using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

  private Vector3 leftBottom;
  private Vector3 rightTop;

  public PlayerBullet _bulletPrefab;
  public float _speed;
  public float _shootDelay;

    public AnimationClip movement;

  void Start () {
    //Set initial position of player 
    leftBottom = Vector3.zero;
    rightTop = Vector3.zero;
    Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);

    Vector3 pos = gameObject.transform.localPosition;

    pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, 0.5f);

    pos.y = Mathf.Lerp(rightTop.y, leftBottom.y, 0.85f);

    gameObject.transform.localPosition = pos;

    /* How to add a new bullet
     *GameObject newShoot = new GameObject();
     *Vector2 bullpos = transform.position;
     *bullpos.y += 0.2f;
     *newShoot.transform.position = bullpos;
     *newShoot.transform.parent = this.transform;
     */

  }

  void Update () {
    //Movement
    float x = Input.GetAxis("Horizontal");
    float y = Input.GetAxis("Vertical");
    float mod = (Input.GetButton("Slow Down")) ? 3f : 10f;

        if (x < 0)
        {
            movement = Resources.Load<AnimationClip>("Animations/Player/TurnLeft.anim");
            this.GetComponent
        }

    Vector2 pos = gameObject.transform.localPosition;
    pos.x += x * mod * Time.deltaTime;
    pos.y += y * mod * Time.deltaTime;

    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
    Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

    max.x -= GetComponent<SpriteRenderer>().bounds.extents.x;
    min.x += GetComponent<SpriteRenderer>().bounds.extents.x;

    max.y -= GetComponent<SpriteRenderer>().bounds.extents.y;
    min.y += GetComponent<SpriteRenderer>().bounds.extents.y;

    pos.x = Mathf.Clamp(pos.x, min.x, max.x);
    pos.y = Mathf.Clamp(pos.y, min.y, max.y);

    gameObject.transform.localPosition = pos;

    //Shoot Bullets
    if (Input.GetButtonDown("Primary Fire")) 
      StartCoroutine (Shoot ());

  }

  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("EnemyBullet")) {
      Destroy(other.gameObject);
      Destroy(gameObject);
      Debug.Log("Player Killed");
    }
  }

  IEnumerator Shoot()
  {
    while (Input.GetButton("Primary Fire")) {
      yield return new WaitForSeconds (_shootDelay);
      for (int i = 0; i < transform.childCount; i++)
      {
        Transform shootPosition = transform.GetChild(i);
        GameObject bullet = Util.LoadPFab("Prefabs/prefab_player_bullet");
        bullet.transform.position = shootPosition.position;
        bullet.transform.rotation = shootPosition.rotation;
        GameObject goBulletLayer = GameObject.Find("Layer_Bullets");
        bullet.transform.parent = goBulletLayer.transform;
      }
    }
  }
}

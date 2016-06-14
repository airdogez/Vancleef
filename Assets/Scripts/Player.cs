using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private Vector3 leftBottom;
    private Vector3 rightTop;

    public PlayerBullet _bulletPrefab;
    public float _speed;
    public float _shootDelay;
    public float graze = 0;
    public float maxGraze = 100;
    public Animator movement;
    public int bombMax = 1;
    public int bombCant = 1;
    public bool isDead;
    public int shootCant = 5;
    public int shootMax = 5;

    void Start()
    {
        isDead = false;
        //Set initial position of player 
        leftBottom = Vector3.zero;
        rightTop = Vector3.zero;
        Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);

        Vector3 pos = gameObject.transform.localPosition;

        pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, 0.5f);

        pos.y = Mathf.Lerp(rightTop.y, leftBottom.y, 0.85f);

        gameObject.transform.localPosition = pos;

        movement = GetComponent<Animator>();

        StartCoroutine(RecoverBullets());
    }

    void Update()
    {
        //Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mod = (Input.GetButton("Slow Down")) ? 3f : 7f;

        if (x < 0)
        {
            movement.SetBool("LeftKey", true);
            movement.SetBool("RightKey", false);
        }

        if (x > 0)
        {
            movement.SetBool("LeftKey", false);
            movement.SetBool("RightKey", true);
        }

        if (x == 0)
        {
            movement.SetBool("LeftKey", false);
            movement.SetBool("RightKey", false);
        }

        Vector2 pos = gameObject.transform.localPosition;
        pos.x += x * mod * Time.deltaTime;
        pos.y += y * mod * Time.deltaTime;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x -= GetComponent<SpriteRenderer>().bounds.extents.x;
        min.x += GetComponent<SpriteRenderer>().bounds.extents.x;

        max.y -= GetComponent<SpriteRenderer>().bounds.extents.y;
        min.y += GetComponent<SpriteRenderer>().bounds.extents.y;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        gameObject.transform.localPosition = pos;

        //Shoot Bullets
        if (Input.GetButtonDown("Primary Fire")){
          StartCoroutine(Shoot());
        }
        //Shoot Bomb
        if (Input.GetButtonDown("Secondary Fire") && bombCant > 0)
            ShootBomb();

    }

    void ShootBomb()
    {
        bombCant--;
        GameController.uiUpdate.SetBombCant(bombCant);
        Vector3 shootPosition = transform.position;
        GameObject bomb = Util.LoadPFab("Prefabs/prefab_bomb");
        bomb.transform.position = shootPosition;
        GameObject goBulletLayer = GameObject.Find("Layer_Bullets");
        bomb.transform.parent = goBulletLayer.transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameController.Instance.AddPuntaje(10);
            Destroy(collision.gameObject);
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
      if(collision.CompareTag("Enemy"))
        KillPlayer();

      if (collision.CompareTag("EnemyBullet"))
      {
        if (Vector3.Distance(transform.position, collision.gameObject.transform.position) <= 0.2)
        {
          Destroy(collision.gameObject);
          KillPlayer();
        }
        graze += 0.1f;
        if (graze > maxGraze){
          bombCant++;
          if (bombCant > bombMax) bombCant = bombMax;
          graze = 0;
        }
        GameController.Instance.UpdateGrazeBar(graze/maxGraze);
        GameController.Instance.UpdateBombs(bombCant);
      }
    }

    IEnumerator RecoverBullets()
    {
      while(true){
        if(shootCant < shootMax)
          shootCant++;
        yield return new WaitForSeconds(.75f);
      }
    }

    IEnumerator Shoot()
    {
      while (shootCant > 0 && Input.GetButton("Primary Fire")){
        for (int i = 0; i < transform.childCount; i++)
        {
          Transform shootPosition = transform.GetChild(i);
          GameObject bullet = Util.LoadPFab("Prefabs/prefab_player_bullet");
          bullet.transform.position = shootPosition.position;
          bullet.transform.rotation = shootPosition.rotation;
          GameObject goBulletLayer = GameObject.Find("Layer_Bullets");
          bullet.transform.parent = goBulletLayer.transform;
          shootCant--;
        }
        yield return new WaitForSeconds(0.5f);
      }
    }

    void KillPlayer()
    {
      isDead = true;
      GetComponent<Player>().enabled = false;
      GameObject explosion = Util.LoadPFab("Prefabs/prefab_explosion");
      explosion.transform.position = this.transform.position;
      explosion.transform.parent = this.transform.parent;
      Destroy(gameObject);
    }
}

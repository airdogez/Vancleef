using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Player : MonoBehaviour
{
    private Vector2 joystickCenter;
    private bool isTouchingControl;

    private Vector3 leftBottom;
    private Vector3 rightTop;

    public GameObject _bulletPrefab;
    public float _speed;
    public float _shootDelay;
    public float graze = 0;
    public float maxGraze = 100;
    public int bombMax = 1;
    public int bombCant = 1;
    public bool isDead;
    public int shootCant = 5;
    public int shootMax = 5;
    private bool canShoot = true;
    private float mod = 7;

    void Start()
    {
        isTouchingControl = false;
        isDead = false;
        //Set initial position of player 
        leftBottom = Vector3.zero;
        rightTop = Vector3.zero;
        Util.ComputeResponsiveScreenPoints(Camera.allCameras[0], out leftBottom, out rightTop);

        Vector3 pos = gameObject.transform.localPosition;

        pos.x = Mathf.Lerp(leftBottom.x, rightTop.x, 0.5f);

        pos.y = Mathf.Lerp(rightTop.y, leftBottom.y, 0.85f);

        gameObject.transform.localPosition = pos;

        StartCoroutine(RecoverBullets());
    }

    void Update()
    {
        //Movement
        float x = 0;
        float y = 0;

#if !UNITY_ANDROID
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        mod = (Input.GetButton("Slow Down")) ? 3f : 7f;

        //Shoot Bullets
        if (Input.GetButton("Primary Fire"))
            Shoot();

        if (Input.GetButtonUp("Primary Fire"))
            canShoot = true;

        //Shoot Bomb
        if (Input.GetButtonDown("Secondary Fire"))
            ShootBomb();
#else
        if (isTouchingControl)
        {
            Vector2 fingerPos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            Vector2 direction = (fingerPos - joystickCenter).normalized;
            x = direction.x;
            y = direction.y;
        }        
#endif

        Vector2 pos = gameObject.transform.localPosition;
        pos.x += x * mod * Time.deltaTime * Modifiers.Instance.playerSpeedModifier;
        pos.y += y * mod * Time.deltaTime * Modifiers.Instance.playerSpeedModifier;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x -= GetComponent<SpriteRenderer>().bounds.extents.x;
        min.x += GetComponent<SpriteRenderer>().bounds.extents.x;

        max.y -= GetComponent<SpriteRenderer>().bounds.extents.y;
        min.y += GetComponent<SpriteRenderer>().bounds.extents.y;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        gameObject.transform.localPosition = pos;

        //SLOWMO
        if (Input.GetKeyDown(KeyCode.A))
        {
            Modifiers.Instance.playerSpeedModifier = 0.5f;
            Modifiers.Instance.globalSpeedModifier = 0.25f;
        }
            
    }

    public void OnPointerEnter(BaseEventData baseEvent)
    {
        isTouchingControl = true;
    }

    public void OnPointerExit(BaseEventData baseEvent)
    {
        isTouchingControl = false;
    }

    public void SetJoystickCenter(Vector2 center)
    {
        joystickCenter = center;
    }

    public void ShootBomb()
    {
        if (bombCant > 0)
        {
            bombCant--;
            GameController.uiUpdate.SetBombCant(bombCant);
            Vector3 shootPosition = transform.position;
            GameObject bomb = Util.LoadPFab("Prefabs/prefab_bomb");
            bomb.transform.position = shootPosition;
            GameObject goBulletLayer = GameObject.Find("Layer_Bullets");
            bomb.transform.parent = goBulletLayer.transform;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameObject diamond = collision.gameObject;
            GameController.Instance.AddPuntaje(diamond.GetComponent<Coin>().score);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("diamond");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Asteroid"))
        {
            GameObject diamond = collision.gameObject;
            KillPlayer();
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            KillPlayer();

        if (collision.CompareTag("EnemyBullet"))
        {
            if (Vector3.Distance(transform.position, collision.gameObject.transform.position) <= 0.15)
            {
                Destroy(collision.gameObject);
                KillPlayer();
            }
            graze += 1f;
            if (graze > maxGraze)
            {
                bombCant++;
                if (bombCant > bombMax) bombCant = bombMax;
                graze = 0;
            }
            GameController.Instance.UpdateGrazeBar(graze / maxGraze);
            GameController.Instance.UpdateBombs(bombCant);
        }
    }

    IEnumerator RecoverBullets()
    {
        while (true)
        {
            if (shootCant < shootMax)
                shootCant++;
            GameController.Instance.UpdateBullets(shootCant);
            yield return new WaitForSeconds(.75f);
        }
    }

    public void Shoot()
    {
        if (!canShoot) return;
        if (shootCant > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shootPosition = transform.GetChild(i);
                GameObject bullet = (GameObject)Instantiate(_bulletPrefab);
                bullet.transform.position = shootPosition.position;
                bullet.transform.rotation = shootPosition.rotation;
                GameObject goBulletLayer = GameObject.Find("Layer_Bullets");
                bullet.transform.parent = goBulletLayer.transform;
            }
            GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("shoot");
            shootCant--;
            GameController.Instance.UpdateBullets(shootCant);
            canShoot = false;
            StartCoroutine(WaitForShooting());
        }
    }

    IEnumerator WaitForShooting()
    {
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
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

    public void ResetShootStatus()
    {
        canShoot = true;
        mod = 7;
    }

    public void ApplyMod()
    {
        mod = 3;
    }
}

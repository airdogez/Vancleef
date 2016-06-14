using UnityEngine;
using System.Collections.Generic;

//Base clase for all Spaceships, defines movement and shoot behaviour
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    [HideInInspector]
    public BaseEnemyLevel currentLevel;

    //The type of bullet
    public GameObject _bullet;
    public List<BaseEnemyLevel> levels;

    public void Shoot(Vector3 origin)
    {
        GameObject bullet = (GameObject)Instantiate(_bullet, new Vector3(transform.position.x + origin.x, transform.position.y + origin.y), Quaternion.Euler(0f, 0f, origin.z));
        bullet.GetComponent<EnemyBullet>().SetSpeed(currentLevel.bulletSpeed);
        GameObject goLayerBullets = GameObject.Find("Layer_Bullets");
        bullet.transform.parent = goLayerBullets.transform;
    }

    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * currentLevel.velocidad;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerBullet"))
        {
            GameController.Instance.AddPuntaje(currentLevel.puntaje);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    public virtual void LevelUp(int level)
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Start()
    {

    }
}

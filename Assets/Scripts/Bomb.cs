using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

  public float speed = 3;
  public float timer = 1;
  public Sprite spriteExplosion;

  void OnTriggerEnter2D(Collider2D other)
  {
    if(!other.CompareTag("Player"))
      Destroy(other.gameObject);
  }

  // Use this for initialization
  void Start ()
  {
    //Move Up
    GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
  }

  // Update is called once per frame
  void Update ()
  {
    //If it gets out of the screen Delete it
    Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
    if(transform.position.y > max.y)
      Destroy(gameObject);

    //if timer reaches 0, explode
    timer -= Time.deltaTime;
    if( timer < 0)
      Explode();

    //GetComponent<CircleCollider2D>().radius += 0.05f;
  }

  void Explode()
  {
    GameObject enemies = GameObject.Find("Layer_Enemies");
    for (int i = 0; i < enemies.transform.childCount; i++)
    {
      Transform enemy = enemies.transform.GetChild(i);
      Destroy(enemy.gameObject);
    }

    GameObject bullets = GameObject.Find("Layer_Bullets");
    for (int i = 0; i < bullets.transform.childCount; i++)
    {
      Transform bullet = bullets.transform.GetChild(i);
      Destroy(bullet.gameObject);
    }

    GameObject objects = GameObject.Find("Layer_Objects");
    for (int i = 0; i < objects.transform.childCount; i++)
    {
      Transform obj = objects.transform.GetChild(i);
      Destroy(obj.gameObject);
    }

    Destroy(gameObject);
  }
}

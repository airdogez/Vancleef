using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

  public float speed = 3;

  void OnTriggerEnter2D(Collider2D other)
  {
    if(!other.CompareTag("Player")){
      if(other.CompareTag("Enemy")){
        Spaceship enemy = (Spaceship) other.gameObject.GetComponent<Spaceship>();
        GameController.Instance.AddPuntaje(enemy.currentLevel.puntaje);
      }
      Destroy(other.gameObject);
    }
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
    //if(transform.position.y > max.y)
    //Destroy(gameObject);
  }

  void Explode()
  {
    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    GameObject.Find("Bomb").GetComponent<AudioSource>().Play();
    GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("bomb");
  }

  void endExplosion()
  {
    Destroy(gameObject);
  }
}

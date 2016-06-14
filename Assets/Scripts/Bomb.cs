using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

  public float speed = 3;
  bool isExploding;

  void OnTriggerEnter2D(Collider2D other)
  {
    if(!other.CompareTag("Player"))
      Destroy(other.gameObject);
  }

  // Use this for initialization
  void Start ()
  {
    isExploding = true;
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
  }

  void Explode()
  {
    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    Vector3 scale = this.transform.localScale;
    scale.x *= 1.1f;
    scale.y *= 1.1f;
    this.transform.localScale = scale;
  }

  void endExplosion()
  {
    Destroy(gameObject);
  }
}

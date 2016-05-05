using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

  public float speed;
  // Use this for initialization
  void Start () {

  }
  // Update is called once per frame
  void Update () {
    GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    
    //If its out of the screen Delete it
    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
    if (transform.position.y < min.y)
      Destroy (gameObject);
  }
}

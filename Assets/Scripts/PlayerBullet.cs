using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

  public float speed = 10;
  // Use this for initialization
  void Start () {
  }

  // Update is called once per frame
  void Update () {
    GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
    if (transform.position.y > max.y)
      Destroy (gameObject);
  }

}

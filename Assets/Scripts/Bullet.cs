using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public float speed = 10;
  private Vector3 rightTop;
  private Vector3 bottomRight;
  // Use this for initialization
  void Start () {
    Util.ComputeResponsiveScreenPoints (Camera.allCameras [0], out bottomRight, out rightTop);
  }

  // Update is called once per frame
  void Update () {
    GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    if (transform.position.y > rightTop.y)
      Destroy (gameObject);
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    Destroy (gameObject);
  }
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  public EnemyBullet _enemyBullet;
  public float speed;

  void OnTriggerEnter2D(Collider2D other)
  {
    if(!other.CompareTag("EnemyBullet")){
      Destroy(other.gameObject);
    }

    if(other.CompareTag("PlayerBullet"))
      //Ever so often it must drop a coin
      Destroy(gameObject);
  }
  // Use this for initialization
  void Start () {
    StartCoroutine(Shoot());
  }

  // Update is called once per frame
  void Update () {
    GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed * -1f;
    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
    if (transform.position.y < min.y)
      Destroy (gameObject);

  }

  IEnumerator Shoot(){
    while(true){
      yield return new WaitForSeconds(1.4f);
      for (int i = 0; i < 3; i++)
      {
        Instantiate(_enemyBullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
      }
    }
  }
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  public EnemyBullet _enemyBullet;
  public float speed;

  Spaceship spaceship;
  private float x;

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
    spaceship = GetComponent<Spaceship>();
    x = 0f;
    StartCoroutine(Shoot());
  }

  // Update is called once per frame
  void Update () {
    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
    x+=0.15f;
    Vector2 sine = new Vector2(Mathf.Sin(x),-1f);
    spaceship.Move(sine.normalized);
    if (transform.position.y < min.y)
      Destroy (gameObject);
  }

  IEnumerator Shoot(){
    while(true){
      yield return new WaitForSeconds(1f);
      for (int i = 0; i < transform.childCount; i++)
      {
        Transform shootPosition = transform.GetChild(i);
				spaceship.Shoot(shootPosition.position);
      }
    }
  }
}

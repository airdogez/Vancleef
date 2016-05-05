using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {


  public Bullet playerBullet;
  public Enemy enemy;

  static public long score;
  static Stack<Bullet> playerBulletStack;
  // Use this for initialization
  void Start () {
    playerBulletStack = new Stack<Bullet>();
    score = 0;

    for (int i = 0; i < 10; i++)
    {
      Bullet newBullet =  Instantiate(playerBullet, Vector3.zero, Quaternion.identity) as Bullet;
      newBullet.gameObject.active = false;
      playerBulletStack.Push(newBullet);
    }
    StartCoroutine(SpawnEnemy());
  }

  // Update is called once per frame
  void Update () {
  }

  IEnumerator SpawnEnemy() {
    while(true){
      float randomX = Random.Range(-4.0f, 4.0f);
      Debug.Log("Spawn enemy");
      Instantiate(enemy, new Vector3(randomX, 1, 0), Quaternion.identity);
      yield return new WaitForSeconds(3);
    }
  }
}

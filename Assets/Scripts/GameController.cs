using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

  public Enemy _enemy;

  static public long score;

  private Vector3 leftBottom;
  private Vector3 rightTop;
  // Use this for initialization
  void Start () {
    score = 0;

    Util.ComputeResponsiveScreenPoints(Camera.main, out leftBottom, out rightTop);

    StartCoroutine(SpawnEnemy());
  }

  // Update is called once per frame
  void Update () {
  }

  IEnumerator SpawnEnemy() {
    while(true){
      float randomX = Random.Range(leftBottom.x + 0.3f, rightTop.x - 0.3f);
      Debug.Log("Spawn enemy");
      Instantiate(_enemy, new Vector3(randomX, rightTop.y, 0), Quaternion.identity);
      yield return new WaitForSeconds(3);
    }
  }
}

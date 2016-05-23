using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

  public GameObject _enemy;

  static public long score;

  private Vector3 leftBottom;
  private Vector3 rightTop;
  private BulletFactory mBulletFactory;
  private GameObject mGoEnemyLayer;

  public BulletFactory BulletFactory{get {return mBulletFactory;}}

  // Use this for initialization
  void Start () {
    mBulletFactory = new BulletFactory();
    //Give reference of gamecontroller to player
    GameObject.Find("prefab_player").GetComponent<Player>();
    score = 0;

    GameObject goEnemyLayer = GameObject.Find("Layer_Enemy");
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
      GameObject enemy = Util.LoadPFab("Prefabs/prefab_enemy");
      enemy.transform.position = new Vector3(randomX, rightTop.y, 0);
      enemy.transform.parent = mGoEnemyLayer.transform;
      yield return new WaitForSeconds(1);
    }
  }
}

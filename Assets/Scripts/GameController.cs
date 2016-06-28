using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
  public static GameController Instance;
  public static GameUIUpdate uiUpdate;
  public static DeathUIUpdate deathScreen;
  public static GameObject selectionScreen;

  //public GameObject player;
  private float startTime = 0;
  private float startTimeSegments = 0;
  private Vector3 leftBottom;
  private Vector3 rightTop;
  private BulletFactory mBulletFactory;
  private GameObject mGoEnemyLayer;
  private GameObject mCoinFactory;
  private Player mGoPlayer;
  private int enemiesLevel = 0;
  private int puntaje = 0;
  private bool beginPlay;

  public BulletFactory BulletFactory { get { return mBulletFactory; } }

  void Awake()
  {
    Instance = this;
  }

  public void StartGameVancleef(){
    beginPlay = true;
    GameObject player = Util.LoadPFab("Prefabs/prefab_player");
    player.transform.position = new Vector2(0, -3.5f);
    player.transform.parent = GameObject.Find("Layer_Player").transform;
    player.SetActive(true);
    mGoPlayer = player.GetComponent<Player>();
    StartCoroutine(SpawnEnemy());
    StartCoroutine(SpawnAsteroid());
        selectionScreen.active = false;
    uiUpdate.gameObject.SetActive(true);
    GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("bgm");
  }

  public void StartGameReol(){
    beginPlay = true;
    GameObject player = Util.LoadPFab("Prefabs/prefab_player_2");
    player.transform.position = new Vector2(0, -3.5f);
    player.transform.parent = GameObject.Find("Layer_Player").transform;
    player.SetActive(true);
    mGoPlayer = player.GetComponent<Player>();
    StartCoroutine(SpawnEnemy());
    StartCoroutine(SpawnAsteroid());
        selectionScreen.active = false;
    uiUpdate.gameObject.SetActive(true);
    GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("bgm");
  }

  void Start()
  {
    beginPlay = false;
    startTime = startTimeSegments = Time.time;
    uiUpdate = GameObject.Find("GOP_UI").GetComponent<GameUIUpdate>();
    mBulletFactory = new BulletFactory();
    //Give reference of gamecontroller to player
    mGoEnemyLayer = GameObject.Find("Layer_Enemies");
    Util.ComputeResponsiveScreenPoints(Camera.main, out leftBottom, out rightTop);
    deathScreen = GameObject.Find("GOP_UI_Death").GetComponent<DeathUIUpdate>();
    deathScreen.gameObject.SetActive(false);
    selectionScreen = GameObject.Find("GOP_UI_Selection");
    uiUpdate.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if(beginPlay){
      float currentTime = Time.time - startTime;
      uiUpdate.UpdateTimerText(currentTime);

      if (enemiesLevel < 3)
      {
        float segmentTime = Time.time - startTimeSegments;
        if (segmentTime >= 15)
        {
          enemiesLevel++;
          startTimeSegments = Time.time;
        }
      }
      if(mGoPlayer.isDead){
        enableDeathScreen();
      }
    }
  }

  IEnumerator SpawnEnemy()
  {
    while (true)
    {
      float randomX = Random.Range(leftBottom.x + 0.3f, rightTop.x - 0.3f);
      GameObject enemy = Util.LoadPFab("Prefabs/prefab_enemy_viking");
      enemy.GetComponent<Spaceship>().LevelUp(enemiesLevel);
      enemy.transform.position = new Vector3(randomX, rightTop.y, 0);
      enemy.transform.parent = mGoEnemyLayer.transform;
      yield return new WaitForSeconds(2f);
    }
  }

    IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f * 10));
            float randomX = Random.Range(leftBottom.x + 0.3f, rightTop.x - 0.3f);
            GameObject enemy = Util.LoadPFab("Prefabs/Asteroid");
            enemy.transform.position = new Vector3(randomX, rightTop.y, 0);
            enemy.transform.parent = mGoEnemyLayer.transform;
        }
    }

    public void AddPuntaje(int p)
  {
    puntaje += p;
    uiUpdate.UpdateScoreText(puntaje);
  }

  public void UpdateGrazeBar(float scale)
  {
    uiUpdate.UpdateGrazeBar(scale);
  }

  public void UpdateBombs(int bombs)
  {
    uiUpdate.SetBombCant(bombs);
  }

  public void UpdateBullets(int bullets)
  {
    uiUpdate.SetBulletCant(bullets);
  }


  public void enableDeathScreen()
  {
    deathScreen.gameObject.SetActive(true);
    deathScreen.UpdateScoreText(puntaje);
    uiUpdate.gameObject.SetActive(false);
  }
}

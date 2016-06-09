using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static UIUpdate uiUpdate;
    private float startTime = 0;
    private float startTimeSegments = 0;
    private Vector3 leftBottom;
    private Vector3 rightTop;
    private BulletFactory mBulletFactory;
    private GameObject mGoEnemyLayer;
    private int enemiesLevel = 0;
    private int puntaje = 0;

    public BulletFactory BulletFactory { get { return mBulletFactory; } }

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        startTime = startTimeSegments = Time.time;
        uiUpdate = GameObject.Find("GOP_UI").GetComponent<UIUpdate>();
        mBulletFactory = new BulletFactory();
        //Give reference of gamecontroller to player
        GameObject.Find("prefab_player").GetComponent<Player>();

        mGoEnemyLayer = GameObject.Find("Layer_Enemies");
        Util.ComputeResponsiveScreenPoints(Camera.main, out leftBottom, out rightTop);
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - startTime;
        uiUpdate.UpdateTimerText(currentTime);

        if (enemiesLevel < 3)
        {
            float segmentTime = Time.time - startTimeSegments;
            if (segmentTime >= 150)
            {
                enemiesLevel++;
                startTimeSegments = Time.time;
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

    public void AddPuntaje(int p)
    {
        puntaje += p;
        uiUpdate.UpdateScoreText(puntaje);
    }
}

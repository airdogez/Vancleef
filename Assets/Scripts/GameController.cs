using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static GameUIUpdate uiUpdate;
    public static DeathUIUpdate deathScreen;
    public static GameObject selectionScreen;

    [HideInInspector]
    public GameObject player;
    public Canvas touchControlCanvas;
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
    private List<string> prefabNames = new List<string>();

    public BulletFactory BulletFactory { get { return mBulletFactory; } }

    void Awake()
    {
        Instance = this;
        prefabNames.Add("prefab_enemy_viking");
        prefabNames.Add("prefab_enemy_reaper");
        prefabNames.Add("prefab_enemy_raven");
    }

    public void StartGameVancleef()
    {
        beginPlay = true;
        player = Util.LoadPFab("Prefabs/prefab_player");
        player.transform.position = new Vector2(0, -3.5f);
        player.transform.parent = GameObject.Find("Layer_Player").transform;
        player.SetActive(true);
        mGoPlayer = player.GetComponent<Player>();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnAsteroid());
        selectionScreen.SetActive(false);
        uiUpdate.gameObject.SetActive(true);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("bgm");

#if UNITY_ANDROID
        touchControlCanvas.gameObject.SetActive(true);
        
        mGoPlayer.SetJoystickCenter(Camera.main.ScreenToWorldPoint(touchControlCanvas.transform.GetChild(0).position));
        EventTrigger trigger = touchControlCanvas.transform.GetChild(0).GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> call = new UnityAction<BaseEventData>(mGoPlayer.OnPointerEnter);
        entry.callback.AddListener(call);
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback = new EventTrigger.TriggerEvent();
        call = new UnityAction<BaseEventData>(mGoPlayer.OnPointerExit);
        entry.callback.AddListener(call);
        trigger.triggers.Add(entry);

        touchControlCanvas.transform.GetChild(1).GetComponent<RepeatButton>().SetRepeatActionAction(mGoPlayer.Shoot);
        touchControlCanvas.transform.GetChild(1).GetComponent<RepeatButton>().SetReleaseAction(mGoPlayer.ResetShootStatus);
        touchControlCanvas.transform.GetChild(1).GetComponent<RepeatButton>().SetPressAction(mGoPlayer.ApplyMod);
        touchControlCanvas.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { mGoPlayer.ShootBomb(); });
#endif

    }

    public void StartGameReol()
    {
        beginPlay = true;
        player = Util.LoadPFab("Prefabs/prefab_player_2");
        player.transform.position = new Vector2(0, -3.5f);
        player.transform.parent = GameObject.Find("Layer_Player").transform;
        player.SetActive(true);
        mGoPlayer = player.GetComponent<Player>();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnAsteroid());
        selectionScreen.SetActive(false);
        uiUpdate.gameObject.SetActive(true);
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("bgm");
		#if UNITY_ANDROID
		touchControlCanvas.gameObject.SetActive(true);

		mGoPlayer.SetJoystickCenter(Camera.main.ScreenToWorldPoint(touchControlCanvas.transform.GetChild(0).position));
		EventTrigger trigger = touchControlCanvas.transform.GetChild(0).GetComponent<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback = new EventTrigger.TriggerEvent();
		UnityAction<BaseEventData> call = new UnityAction<BaseEventData>(mGoPlayer.OnPointerEnter);
		entry.callback.AddListener(call);
		trigger.triggers.Add(entry);

		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerExit;
		entry.callback = new EventTrigger.TriggerEvent();
		call = new UnityAction<BaseEventData>(mGoPlayer.OnPointerExit);
		entry.callback.AddListener(call);
		trigger.triggers.Add(entry);

		touchControlCanvas.transform.GetChild(1).GetComponent<RepeatButton>().SetRepeatActionAction(mGoPlayer.Shoot);
		touchControlCanvas.transform.GetChild(1).GetComponent<RepeatButton>().SetReleaseAction(mGoPlayer.ResetShootStatus);
		touchControlCanvas.transform.GetChild(1).GetComponent<RepeatButton>().SetPressAction(mGoPlayer.ApplyMod);
		touchControlCanvas.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { mGoPlayer.ShootBomb(); });
		#endif
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
        if (beginPlay)
        {
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
            if (mGoPlayer.isDead)
            {
                enableDeathScreen();
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float randomX = Random.Range(leftBottom.x + 0.3f, rightTop.x - 0.3f);
            GameObject enemy = Util.LoadPFab("Prefabs/" + prefabNames[Random.Range(0, prefabNames.Count)]);
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

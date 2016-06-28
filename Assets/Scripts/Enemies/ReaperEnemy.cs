using UnityEngine;
using System.Collections;

public class ReaperEnemy : Spaceship
{

    private GameObject player;
    private Vector2 min;
    private float startY;
    private bool hasDirection = false;
    private Quaternion tempRot;
    private Vector2 direction;
    private float rotTimer;
    private bool timeCounting;
    private float startTime;

    public override void Start()
    {
        timeCounting = false;
        rotTimer = 0f;
        player = GameController.Instance.player;
        startY = transform.position.y;
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    }

    public override void Update()
    {
        if (player == null) return;
        if (startY - transform.position.y < 2)
            Move(Vector2.down);
        else
        {
            if (!hasDirection)
            {
                direction = (player.transform.position - transform.position).normalized;
                tempRot = transform.rotation;
                hasDirection = true;
            }
            else
            {
                if(rotTimer < 1f)
                {
                    Move(Vector2.zero);

                    rotTimer += 0.05f;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Slerp(tempRot, Quaternion.Euler(0, 0, angle + 90), rotTimer);
                }
                else
                {
                    if(!timeCounting)
                    {
                        startTime = Time.time;
                        timeCounting = true;
                    }

                    float elapsedTime = Time.time - startTime;
                    if(elapsedTime > 2)
                    {
                        timeCounting = false;
                        hasDirection = false;
                        rotTimer = 0f;
                    }
                    else
                        Move(direction);
                }
            }
        }

        if (transform.position.y < min.y)
            Destroy(gameObject);
    }

    public override void LevelUp(int level)
    {
        if(level < 3)
        {
            currentLevel = levels[level];
            GetComponent<Animator>().runtimeAnimatorController = currentLevel.anim;
        }
        else
        {
            currentLevel = levels[2];
            GetComponent<Animator>().runtimeAnimatorController = currentLevel.anim;
        }
    }
}
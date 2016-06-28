using UnityEngine;
using System.Collections;

public class RavenEnemy : Spaceship {
    
    public override void Start()
    {
        StartCoroutine(Shoot());
    }

    public override void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Move(Vector2.down);
        if (transform.position.y < min.y)
            Destroy(gameObject);
    }

    public override void LevelUp(int level)
    {
        if (level < 3)
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

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentLevel.shootingFreq / Modifiers.Instance.globalSpeedModifier);
            foreach(Vector3 vec in currentLevel.bulletSpawnPoints)
            {
                Shoot(vec);
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class VikingEnemy : Spaceship {

    private float x = 0;

    public override void Start()
    {
        StartCoroutine(Shoot());
    }

    public override void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        x += 0.15f;
        Vector2 sine = new Vector2(Mathf.Sin(x), -1f);
        Move(sine);
        if (transform.position.y < min.y)
            Destroy(gameObject);
    }

    public override void LevelUp(int level)
    {
        currentLevel = levels[level];
        GetComponent<Animator>().runtimeAnimatorController = currentLevel.anim;
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
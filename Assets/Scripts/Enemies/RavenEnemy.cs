using UnityEngine;
using System.Collections;

public class RavenEnemy : Spaceship {
    
    public override void Start()
    {
        LevelUp(0);
        StartCoroutine(Shoot());
    }

    public override void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Move(Vector2.down * currentLevel.velocidad);
        if (transform.position.y < min.y)
            Destroy(gameObject);
    }

    public override void LevelUp(int level)
    {
        currentLevel = levels[level];
        GetComponent<SpriteRenderer>().sprite = currentLevel.sprite;
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentLevel.shootingFreq);
            foreach(Vector3 vec in currentLevel.bulletSpawnPoints)
            {
                Shoot(vec);
            }
        }
    }
}
using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    float speed;
    Vector2 direction;
    int hits;

    // Use this for initialization
    void Start ()
    {
        hits = 4;
        float r = Random.Range(-1.0f, 1.0f);
        direction = new Vector2(r, -1);
        speed = 3;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 FieldMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 FieldMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        var PosX = transform.position.x;
        var Width = GetComponent<SpriteRenderer>().bounds.extents.x;
        var PosY = transform.position.y;
        var Height = GetComponent<SpriteRenderer>().bounds.extents.y;

        if (hits == 0)
        {
            Destroy(gameObject);
        }

        if (PosX - Width / 2 <= FieldMin.x && direction.x < 0)
        {
            direction.x *= -1;
            hits--;
        }

        if (PosX + Width / 2 >= FieldMax.x && direction.x > 0)
        {
            direction.x *= -1;
            hits--;
        }

        if (PosY - Height / 2 <= FieldMin.y && direction.y < 0)
        {
            direction.y *= -1;
            hits--;
        }

        if (PosY + Height / 2 >= FieldMax.y && direction.y > 0)
        {
            direction.y *= -1;
            hits--;
        }

        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}

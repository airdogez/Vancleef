using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
    float speed;
    Vector2 direction;
    int hits;

    Vector2 FieldMin;
    Vector2 FieldMax;

    float Width;
    float Height;

    float rot;

    // Use this for initialization
    void Start ()
    {
        hits = 4;
        float r = Random.Range(-1.0f, 1.0f);
        direction = new Vector2(r, -1);
        speed = 3;

        FieldMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        FieldMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        
        Width = GetComponent<SpriteRenderer>().bounds.extents.x;
        Height = GetComponent<SpriteRenderer>().bounds.extents.y;

        rot = Random.Range(1.0f, 5.0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        var PosX = transform.position.x;
        var PosY = transform.position.y;
        transform.Rotate(Vector3.forward * rot);

        if (hits == 0)
        {
            if (PosX + Width / 2 < FieldMin.x || PosX - Width / 2 > FieldMax.x || PosY + Height / 2 < FieldMin.y || PosY - Height / 2 > FieldMax.y)
            {
                Destroy(gameObject);
            }
        }
        else
        {
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
}

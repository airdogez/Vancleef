using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

  private float speed;
  public int score;
  private Sprite sprite;

  // Use this for initialization
  void Start () {
    speed = 50f;
  }

  public void setScore(int score){
    this.score = score;
  }
  public void setSprite(Sprite sprite){
    this.sprite = sprite;
  }

  // Update is called once per frame
  void Update () {
    Vector2 bottom = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
    GetComponent<Rigidbody2D>().velocity = Vector2.down * speed * Time.deltaTime;
    GetComponent<SpriteRenderer>().sprite = sprite;
    if (transform.position.y <  bottom.y)
    {
      Destroy(gameObject);
    }
  }
}

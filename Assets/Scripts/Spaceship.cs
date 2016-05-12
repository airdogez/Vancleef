using UnityEngine;
using System.Collections;

//Base clase for all Spaceships, defines movement and shoot behaviour
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

  //Movement speed
  public float _speed;
  //Delay for shooting
  public float _shootDelay;
  //The type of bullet
  public GameObject _bullet;

  public void Shoot(Transform origin){
    var bullet = (GameObject) Instantiate(_bullet, origin.position, origin.rotation);
    GameObject goLayerBullets = GameObject.Find("Layer_Bullets");
    bullet.transform.parent = goLayerBullets.transform;
  }

  public void Move(Vector2 direction){
    GetComponent<Rigidbody2D>().velocity = direction * _speed;
  }
}

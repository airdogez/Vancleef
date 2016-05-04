using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

  public float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed; 
	
	}
}

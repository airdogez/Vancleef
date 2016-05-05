using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other)
  {
    Destroy(other.gameObject);
    Destroy(gameObject);
  }
  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }
}

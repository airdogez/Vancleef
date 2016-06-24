using UnityEngine;

public class Explosion : MonoBehaviour {

  void playAudio(){
    GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
  }

  void OnAnimationFinish(){
    Destroy(gameObject);
  }

}

using UnityEngine;

public class Explosion : MonoBehaviour {

  void playAudio(){
    GameObject.Find("SoundManager").GetComponent<SoundManager>().playSound("explosion");
  }

  void OnAnimationFinish(){
    Destroy(gameObject);
  }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

  public Dictionary<string, AudioSource> mAudioDictionary;
  // Use this for initialization
  void Start () {
    mAudioDictionary = new Dictionary<string, AudioSource>();
    mAudioDictionary.Add("shoot", new AudioSource());
    mAudioDictionary.Add("explosion", new AudioSource());
    mAudioDictionary.Add("diamond", new AudioSource());
    mAudioDictionary.Add("bgm", new AudioSource());

  }

  // Update is called once per frame
  void Update () {

  }
}

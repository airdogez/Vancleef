using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
[Serializable] public class DictionaryAudioSource : SerializableDictionary<string, AudioSource>{}

public class SoundManager : MonoBehaviour {

  public DictionaryAudioSource mAudioSources;

  public void playSound(string key){
    mAudioSources[key].GetComponent<AudioSource>().Play();
  }
}

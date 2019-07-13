using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgmousic : MonoBehaviour {
    //背景音乐音量
    AudioSource bgmusicvolume;
	// Use this for initialization
	void Start () {
        bgmusicvolume = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        bgmusicvolume.volume = UImanager.instance.Volume.value;
        //print(bgmusicvolume.volume);
	}
}

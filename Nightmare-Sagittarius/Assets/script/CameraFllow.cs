using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour {
    [Tooltip("人物")]
    public Transform player;
    [Tooltip("偏移量")]
    public Vector3 offest;
    [Tooltip("移动速度")]
    public float movespeed = 5f;
    
	// Use this for initialization
	void Start () {
        //计算偏移量
        offest = transform.position - player.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        //计算相机到人物之间的距离
        Vector3 playlocm =player.position + offest ;
        //transform.position = playlocm;
        //使其运动的更加缓和
        //transform.eulerAngles = player.eulerAngles;
        
        transform.position = Vector3.Lerp(transform.position , playlocm ,
                                          movespeed * Time.timeScale);
	}
}

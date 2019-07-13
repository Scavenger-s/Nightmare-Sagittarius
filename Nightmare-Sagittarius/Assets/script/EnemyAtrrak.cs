using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtrrak : MonoBehaviour {
    Animator animator;//定义animator
    public int attackdamage = 12;//怪物攻击力
    public int attackinerval = 1;//攻击时间间隔
    float timer = 0;
    bool inrange;//是否在攻击范围之内
    GameObject player;
    Playertblood playerblood;
   
    //人物本来颜色
    
    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();//获取aimator组件 
        player = GameObject.FindGameObjectWithTag("Player");
        playerblood = player.GetComponent<Playertblood>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= attackinerval && inrange == true) {
            timer = 0;//重置时间常量
            if (playerblood.currentblood > 0)
            {
                //减血
                playerblood.Takedamage(attackdamage);
                Debug.Log("player is died");
               
            }
            else {
                playerblood.Playerdeath();
               
            }

        }
	}
    //进入碰撞
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inrange = true;
        }
    }

    //离开碰撞

    private void OnTriggerExit(Collider other)
    {
        inrange = false;

    }
}

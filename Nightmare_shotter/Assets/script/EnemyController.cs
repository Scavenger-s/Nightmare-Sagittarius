using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemy;
    //怪物生成点
    public Transform enemypos;
    //间隔时间
    public float interval = 5f;
    //大怪生成时间
    public float boissinterval = 10f;
	// Use this for initialization
	void Start () {
        StartCoroutine("Produceenemy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Produceenemy() {
        while (true) {
            if (enemy.tag == "boiss")
            {
                yield return new WaitForSeconds(boissinterval);
                //生成怪物
                GameObject go = Instantiate(enemy, enemypos.position, Quaternion.identity);
                //间隔生成时间
                
            }
            else {
                //生成怪物
                GameObject go = Instantiate(enemy, enemypos.position, Quaternion.identity);
                //间隔生成时间
                yield return new WaitForSeconds(interval);
            }

            
        }
    }
}

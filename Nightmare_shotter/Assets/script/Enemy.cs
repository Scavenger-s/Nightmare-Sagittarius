using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [Tooltip("初始血量")]
    public int starthp = 100;
    [Tooltip("当前血量")]
    public int currenthp;
    private Animator animator;
    public AudioClip death;
    //敌人死后加分
    public int enemydiedscore;
    //死亡
    bool isdied = false;
    //下沉
    bool issink = false;
    //下沉速度
    public float sinkspeed = 1f;
    

	// Use this for initialization
	void Start () {
        //给当前血量赋初值
        currenthp = starthp;
        //获取动画
        animator = gameObject.GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (issink) {
            //transform.Translate(Vector3.down*Time.deltaTime*sinkspeed);
        }

        if (currenthp >= 0) {
            animator.SetBool("enemymove", true);
        }
        else
            animator.SetBool("enemymove", false);
    }

    /// <summary>
    /// 怪物受伤
    /// </summary>
    
    public void TakeDamage(int damage) {
        if (isdied)
            return;
        
            //减血
          currenthp -= damage;
          GetComponent<AudioSource>().Play();
        if (currenthp <=0) {
            Died();
            StartSink();
        }
    }
    /// <summary>
    /// enemy死亡
    /// </summary>
    public void Died() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = death;
        audio.Play();
        isdied = true;
        animator.SetBool("enemydeath" , true);
        UImanager.instance.count += enemydiedscore;
    }
    /// <summary>
    /// 开始下沉
    /// </summary>
    public void StartSink() {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        issink = true;
        Destroy(gameObject ,1.5f);
    }
}

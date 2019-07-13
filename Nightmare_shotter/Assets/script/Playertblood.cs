using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertblood : MonoBehaviour {
    public int blood = 100;//人物血量
    public int currentblood;//人物实时血量
    Animator animator;//定义animator

    public AudioClip death;
    
	// Use this for initialization
	void Start () {
        currentblood = blood;//初始化
        animator = gameObject.GetComponent<Animator>();//获取aimator组件 
       
    }
	
	// Update is called once per frame
	void Update () {
       
	}
    /// <summary>
    /// 人物受伤方法
    /// </summary>
    public void Takedamage(int damage) {
        currentblood -= damage;
        UImanager.instance.hp = currentblood;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        StartCoroutine("hurt");
        if (currentblood <= 0)
        {
            Playerdeath();
            UImanager.instance.hurtpanel.SetActive(false);
        }
    }
    /// <summary>
    /// 人物死亡
    /// </summary>
    public void Playerdeath() {
        animator.SetBool("playerdeath", true);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = death;
        audio.Play();
        UImanager.instance.hp = 0;
        Time.timeScale = 0;
        //显示失败界面
        UImanager.instance.losspanel.SetActive(true);
        UImanager.instance.lossscore = UImanager.instance.count;
        UImanager.instance.loss.text += UImanager.instance.lossscore;
    }
    IEnumerator hurt() {
        UImanager.instance.hurtpanel.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UImanager.instance.hurtpanel.SetActive(false);
    }
  
}

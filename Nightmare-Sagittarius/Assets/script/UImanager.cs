using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    public static UImanager instance;
    //控制声音的slider
    public Slider Volume;
    //血条
    //public Slider Blood;
    //赢的面板
    public GameObject winpanel;
    //输的面板
    public GameObject losspanel;
    //分数
    public Text score;
    //分数
    public int count = 0;
    //赢的分数
    public int winscore;
    //输的分数
    public int lossscore;
    public Text loss;
    //开始面板
    public GameObject startpanel;
    //简介面板
    public GameObject intrudctionpanel;
    //hp
    public int hp = 100;
    public Slider Blood;
    //人物受伤面板
    public GameObject hurtpanel;
    public GameObject hpandscorepanel;
    // Use this for initialization
    void Start()
    {
        instance = this;
        hurtpanel.SetActive(false);
        Blood.value = hp;
        hpandscorepanel.SetActive(true);
        //为volume设置范围
        Volume.maxValue = 1f; Volume.minValue = 0f;
        //设置volume的值
        Volume.value = 0.5f;
        //隐藏面板
        losspanel.SetActive(false);
        winpanel.SetActive(false);
        score.text = "Score:" + count;
        intrudctionpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:" + count;
        //达到这个分数则赢了
        if (count >= winscore)
        {
            winpanel.SetActive(true);
            Time.timeScale = 0;
            count = 0;
            hpandscorepanel.SetActive(false);
        }
        Blood.value = hp;
    }
    /// <summary>
    /// 场景跳转
    /// </summary>
  
    public void SceneOnClick(int a) {
        SceneManager.LoadScene(a);
        Time.timeScale = 1;
       
    }
    public void ExitOnClick() {
        Application.Quit();
    }
    /// <summary>
    /// intrudction绑定
    /// </summary>
    public void OnIntrudctionClick()
    {
        startpanel.SetActive(false);
        intrudctionpanel.SetActive(true);
    }
    /// <summary>
    /// 返回按钮绑定
    /// </summary>
    public void OnBackClick() {
        startpanel.SetActive(true);
        intrudctionpanel.SetActive(false);
    }
   
}

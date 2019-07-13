using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershotting : MonoBehaviour {
    public Material effectshot;
    LineRenderer linerender;
    public float distance = 10f;
    float starttime = 0.15f;
    public float endtime = 0.2f;
    float timer = 0f;
    [Tooltip("射线宽度")]
    public float linewidth = 0.05f;
    public Material material;
    //可射击的层
    LayerMask shootmask;
    //可设计的点
    RaycastHit shootpoint;
    Ray shootray;
    //攻击力
    public int shootdamage = 100;
    public int shootstartdamage = 20;
    ParticleSystem gun;
    Light lighting;
    AudioSource playergun;
    public AudioClip enemyclip;
    //粒子特效
    public GameObject ps;
    ParticleSystem effects;
    
    bool effectplay = false;
    public int useeffectscore = 100;
    public int cosumeeffect = 50;
    // Use this for initialization
    void Start () {
        
        gameObject.AddComponent<LineRenderer>();
        gameObject.GetComponent<LineRenderer>().enabled = false;
        linerender = gameObject.GetComponent<LineRenderer>();
        //linerender.useWorldSpace = false;
        linerender.receiveShadows = false;
        //linerender.SetPosition(1, new Vector3(0, 0, distance));
        linerender.material = material;
        linerender.startWidth = linewidth;
        linerender.endWidth = linewidth;
        shootmask = LayerMask.GetMask("floor");
        lighting = gameObject.GetComponent<Light>();
        gun = transform.GetChild(0).GetComponent<ParticleSystem>();
        //获取开枪声音
        playergun = gameObject.GetComponent<AudioSource>();
        effects = ps.GetComponent<ParticleSystem>();
        effects.Stop();
    }
    float effecttime = 0f;
    float endeffect = 1.5f;
    // Update is called once per frame
    void Update () {
        //起始点
        shootray.origin = transform.position;
        shootray.direction = transform.forward;//射线的方向为枪口正前方
        linerender.SetPosition(0, transform.position);//起始点
        timer += Time.deltaTime;
        //鼠标左键
        if (Input.GetMouseButton(0) && timer > endtime)
        {
            //发射一条射线
            if (Physics.Raycast(shootray, out shootpoint, 100, shootmask))
            {
                Enemy health = shootpoint.collider.gameObject.GetComponent<Enemy>();
                if (health != null)
                {
                    ParticleSystem hit = health.transform.GetChild(0).
                                         GetComponent<ParticleSystem>();
                    hit.Play();
                    
                    health.TakeDamage(shootdamage);
                    Debug.Log("health:" + health.name);
                }
                linerender.SetPosition(1, shootpoint.point);

            }
            //没有射到物体
            else
            {
                linerender.SetPosition(1, shootray.origin + shootray.direction * 100);
            }
            timer = 0f;
            linerender.enabled = true;
            lighting.enabled = true;
            gun.Play();
            playergun.Play();
        }
        else {
            linerender.enabled = false;
            lighting.enabled = false;
            gun.Stop();


        }
        if (Input.GetKey(KeyCode.R)&&UImanager.instance.count>= useeffectscore) {
            StartCoroutine("EffectsDisplay2");

        }

    }
    IEnumerator EffectsDisplay2() {
        ps.SetActive(true);
        effects.Play();
        shootdamage = 4*shootstartdamage;
        UImanager.instance.count -= cosumeeffect;
        linerender.material = effectshot;
        linerender.endWidth = linerender.startWidth = 0.2f;
        yield return new WaitForSeconds(2f);
        linerender.material = material;
        linerender.endWidth = linerender.startWidth = linewidth;
        shootdamage = shootstartdamage;
    }
   
}

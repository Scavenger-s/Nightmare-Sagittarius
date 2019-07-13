using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float movespeed  = 10f;
    //动画
    public Animator animator;
    //鼠标旋转能识别的层
    LayerMask floor;
    Rigidbody rig;
	// Use this for initialization
	void Start () {
        //获取animator
        animator = gameObject.GetComponent<Animator>();
        floor = LayerMask.GetMask("floor");
        rig = gameObject.GetComponent<Rigidbody>();
        
    }
    bool pause = true;
	// Update is called once per frame
	void Update () {
        //获取水平轴
        float h = Input.GetAxis("Horizontal");
        //获取垂直轴
        float v = Input.GetAxis("Vertical");
        //Debug.Log("h +" +h+"/n v="+v);
        PlayerMove(h , v);
        PlayerRotate();
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        /*
        if (Input.GetKey(KeyCode.Space)) {
            if (pause)
            {
                Time.timeScale = 0;
                pause = !pause;
            }
            else
                Time.timeScale = 1;
                
        }*/
    }
    //移动
    public void PlayerMove(float h , float v) {
        //人物的移动控制
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(-Vector3.left * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * movespeed * Time.deltaTime);
        bool ismove = h != 0 || v != 0;
        if (ismove)
        {
            animator.SetBool("playermove", true);
        }
        else {
            animator.SetBool("playermove", false);
        }
        /*
        if(Input.GetKey(KeyCode.Space))
            animator.SetBool("playerdeath", true);
        if (Input.GetKey(KeyCode.F))
            animator.SetBool("playerdeath", false);*/
    }
    //旋转
    public void PlayerRotate() {
        //从主相机发送一条射线
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //创建一个点击到点的变量
        RaycastHit floorhit;
        //进行射线投射，floor检测的层
        if (Physics.Raycast(CamRay ,out floorhit , 100f , floor)) {
            //创建一个向量计算人物到射线投射点的向量
            Vector3 playertoray = floorhit.point - transform.position;
           
            playertoray.y = 0f;
            //创建一个四元数
            Quaternion newrotation = Quaternion.LookRotation(playertoray);
            rig.MoveRotation(newrotation);
            
        }
    }
}

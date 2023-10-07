using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;


    public float speed = 5f;
    CharacterController2D cc;//引用控制脚本
    Animator anim;//引用动画组件
    Rigidbody2D rigid;//引用碰撞组件
    bool jump;

    float cmove;
    void Start()
    {
       
        cc = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cmove = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(cmove));//设置speed，供后面动画切换
        cmove *= speed;
        jump = Input.GetButton("Jump");
       
        
        



    }

    private void FixedUpdate()
    {
        cc.Move(cmove, jump);
    }
}
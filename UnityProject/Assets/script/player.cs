﻿
using UnityEngine;

public class player : MonoBehaviour
{ 
    [Header("速度"),Range(0f, 100f)]
    public float speed = 3.5f;
    [Header("跳躍"), Range(100, 2000)]
    public int jump = 300;
    [Header("是否在地板上"),Tooltip("用來判斷角色是否在地板上。")]
    public bool isGround = false;
    [Header("角色名稱")]
    public string name = "KID";
    [Header("2D鋼體")]
    public Rigidbody2D r2d;
    public Animator ani;
    //#endregion

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        r2d.AddForce(new Vector2(speed*h, 0));
        ani.SetBool("跑步開關", h != 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGround==true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }
    private void Dead()
    {

    }
    private void Update()
    {
        Move();
        Jump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            isGround = true;
        }
    }
}
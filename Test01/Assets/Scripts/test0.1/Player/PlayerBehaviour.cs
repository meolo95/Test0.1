using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{

    protected Rigidbody2D rigid;
    protected Animator anim;

    protected PlayerLife life;
    protected PlayerManage player = new PlayerManage(20, 30, 5, 5);

    protected BoxCollider2D Col;
    protected Vector2 Colsize;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Col = GetComponent<BoxCollider2D>();
        Colsize = Col.size;
    }

    public void Update()
    {
    }

}

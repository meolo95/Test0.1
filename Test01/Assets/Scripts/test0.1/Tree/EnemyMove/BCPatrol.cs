using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCPatrol : EnemyManage, IMove
{
    [SerializeField] float x;
    [SerializeField] float y;
    Vector3 patrol;
    [SerializeField] float speed;
    Vector3 pos;
    Vector3 dir;
    Vector3 rid;
    float patdis;
    float posdis;
    bool ispat;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Debug.Log("Awake!");
        pos = transform.position;
        patrol = pos + new Vector3(x, y);
    }
    private void Start()
    {
    }
    public void Move()
    {
        dir = (patrol - transform.position).normalized;
        rid = (pos - transform.position).normalized;
        patdis = Vector3.Distance(transform.position, patrol);
        posdis = Vector3.Distance(transform.position, pos);
        if (patdis < 1f)
        {
            ispat = true;
        }
        if (posdis < 1f)
        {
            ispat = false;
        }
        if (!ispat)
        {
            rigid.velocity = dir * speed;
        }
        else
        {
            rigid.velocity = rid * speed;
        }
        if (rigid.velocity.x > 0)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
    }


}

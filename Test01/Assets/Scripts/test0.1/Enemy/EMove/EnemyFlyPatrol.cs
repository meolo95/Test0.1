using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyPatrol : EnemyManage, IMove
{
    [SerializeField] float x;
    [SerializeField] float y;
    Vector3 patrol;
    [SerializeField] float speed;
    Vector3 pos;
    Vector3 dir;
    float patdis;
    float posdis;
    bool ispat;
    protected override void Awake()
    {
        base.Awake();
        pos = transform.position;
        patrol = pos + new Vector3(x, y);
        dir = (patrol - pos).normalized;
    }
    public void Move()
    {
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
            rigid.velocity = -dir * speed;
        }
        if (rigid.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

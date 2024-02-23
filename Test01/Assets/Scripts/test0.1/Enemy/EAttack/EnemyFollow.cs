using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyManage, IAttack
{
    [SerializeField] float speed;
    public void Attack()
    {

        if (PlayerManage.Instance.PlayerPosition().x < transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (PlayerManage.Instance.PlayerPosition().x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        Vector3 dir = (PlayerManage.Instance.PlayerPosition() - transform.position).normalized;
        rigid.velocity = dir * speed;
    }
}

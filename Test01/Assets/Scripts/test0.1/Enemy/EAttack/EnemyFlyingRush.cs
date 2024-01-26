using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingRush : EnemyManage, IAttack, IBreak
{
    [SerializeField] float speed;
    [SerializeField] float time;
    [SerializeField] float delay;

    bool attack;

    Vector3 playerPos;
    Vector2 pos;
    public void Attack()
    {
        if (attack)
        {
            Rush();
        }
        StartRush();
    }
    public void Break()
    {
        StopRush();
    }

    void Rush()
    {
        if (playerPos.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        rigid.velocity = new Vector2(pos.x * speed, pos.y * speed);
    }

    IEnumerator IERush;

    void StartRush()
    {
        if(IERush == null)
        {
            IERush = ERush();
            StartCoroutine(IERush);
        }
    }
    void StopRush()
    {
        if (IERush != null)
        {
            StopCoroutine(IERush);
            IERush = null;
        }
    }

    IEnumerator ERush()
    {
        AnimSetTrue("IsReady");
        yield return new WaitForSeconds(delay);
        GetTarget();
        AnimSetTrue("IsAttack");
        attack = true;
        yield return new WaitForSeconds(time);
        AnimSetTrue("IsReady");
        rigid.velocity = Vector3.zero;
        attack = false;
        IERush = null;
    }

    public void GetTarget()
    {
        playerPos = PlayerManage.Instance.PlayerPosition();
        float dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y - transform.position.y, 2));
        pos = new Vector2((playerPos.x - transform.position.x) / dev, (playerPos.y - transform.position.y) / dev);
    }
}

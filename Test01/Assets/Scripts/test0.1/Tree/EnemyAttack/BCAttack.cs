using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCAttack : EnemyManage, IAttack, IBreak
{
    Vector3 pos;
    Vector3 playerPos;
    Vector3 dir;
    [SerializeField] float speed;
    [SerializeField] float delay;
    public void Attack()
    {
        StartRush();
    }
    public void Break()
    {
        StopRush();
    }

    IEnumerator IERush;

    void StartRush()
    {
        if (IERush == null)
        {
            IERush = IRush();
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

    IEnumerator IRush()
    {
        SoundManager.Instance.Play("Growl");
        pos = transform.position;
        playerPos = PlayerManage.Instance.PlayerPosition();
        dir = (playerPos - pos).normalized;
        rigid.velocity = dir * speed;
        yield return new WaitForSeconds(delay);
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(delay);
        rigid.velocity = -dir * speed;
        yield return new WaitForSeconds(delay);
        IERush = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : EnemyManage, IHit
{
    [SerializeField] float stun = 6f;


    public void Hit()
    {
        OnPull();
    }

    public void OnPull()
    {
        Vector3 playerPos = PlayerManage.Instance.PlayerPosition();
        rigid.velocity = Vector3.zero;
        if (playerPos.x < transform.position.x)
        {
            rigid.AddForce(new Vector2(stun, stun), ForceMode2D.Impulse);
        }
        else if (playerPos.x >= transform.position.x)
        {
            rigid.AddForce(new Vector2(-stun, stun), ForceMode2D.Impulse);
        }
    }

    IEnumerator IEHit;

    private void HitStart()
    {
        IEHit = hitCoolTime();
        StartCoroutine(IEHit);
    }

    private void HitStop()
    {
        StartCoroutine(IEHit);
        IEHit = null;
    }


    IEnumerator hitCoolTime()
    {
        OnPull();
        yield return null;
    }

}

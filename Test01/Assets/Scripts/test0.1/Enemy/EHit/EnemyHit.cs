using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : EnemyManage, IHit
{
    [SerializeField] float stun = 4f;


    public void Hit()
    {
        OnPull();
    }

    public void OnPull()
    {
        SoundManager.Instance.SummonPlay("Hit", transform.position);
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

}

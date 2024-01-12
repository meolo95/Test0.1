using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IHit
{
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Hit()
    {
        OnPull();
    }

    public void OnPull()
    {
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition();
        rigid.velocity = Vector3.zero;
        if (playerPos.x < transform.position.x)
        {
            rigid.AddForce(new Vector2(6, 6), ForceMode2D.Impulse);
        }
        else if (playerPos.x >= transform.position.x)
        {
            rigid.AddForce(new Vector2(-6, 6), ForceMode2D.Impulse);
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

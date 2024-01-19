using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingRush : MonoBehaviour, IAttack, IBreak
{
    [SerializeField] float speed;
    [SerializeField] float time;
    [SerializeField] float delay;

    bool attack;

    Vector3 playerPos;
    Vector2 pos;

    Rigidbody2D rigid;
    Animator anim;
    int isAttack;
    int isTarget;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAttack = Animator.StringToHash("IsAttack");
        isTarget = Animator.StringToHash("IsTarget");

    }
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
        anim.SetBool(isTarget, true);
        yield return new WaitForSeconds(delay);
        GetTarget();
        anim.SetBool(isAttack, true);
        anim.SetBool(isTarget, false);
        attack = true;
        yield return new WaitForSeconds(time);
        anim.SetBool(isAttack, false);
        anim.SetBool(isTarget, true);
        rigid.velocity = Vector3.zero;
        attack = false;
        IERush = null;
    }

    public void GetTarget()
    {
        playerPos = PlayerLocation.Instance.PlayerPosition();
        float dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y - transform.position.y, 2));
        pos = new Vector2((playerPos.x - transform.position.x) / dev, (playerPos.y - transform.position.y) / dev);
    }
}

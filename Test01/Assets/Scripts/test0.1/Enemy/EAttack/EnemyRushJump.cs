using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRushJump : EnemyManage, IAttack
{

    [SerializeField] float speed;
    [SerializeField] float accel;
    [SerializeField] float delay;
    [SerializeField] float jumpSpeed;

    BoxCollider2D box;

    RaycastHit2D rayHit;
    Vector2 rayPos;

    protected override void Awake()
    {
        base.Awake();
        box = transform.GetChild(2).GetComponent<BoxCollider2D>();
    }
    public void Attack()
    {
        RushJump();
        Jump();
    }

    void RushJump()
    {
        AnimSetTrue("IsAttack");
        rayPos = transform.position;
        rayPos += box.offset;
        if (PlayerManage.Instance.PlayerPosition().x < transform.position.x)
        {
            rigid.AddForce(new Vector2(speed * - accel, 0f), ForceMode2D.Impulse);
            rayHit = Physics2D.Raycast(rayPos, Vector3.left, 3f, LayerMask.GetMask("Platform"));
            if (rigid.velocity.x < -1 * speed)
            {
                rigid.velocity = new Vector2(-1 * speed, rigid.velocity.y);
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (PlayerManage.Instance.PlayerPosition().x > transform.position.x)
        {
            rigid.AddForce(new Vector2(speed * accel, 0f), ForceMode2D.Impulse);
            rayHit = Physics2D.Raycast(rayPos, Vector3.left, -3f, LayerMask.GetMask("Platform"));
            if (rigid.velocity.x > 1 * speed)
            {
                rigid.velocity = new Vector2(1 * speed, rigid.velocity.y);
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Jump()
    {
        if (rayHit.collider != null && IECool == null)
        {
            CoolStart();
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }





    IEnumerator IECool;
    void CoolStart()
    {
        IECool = Cool();
        StartCoroutine(IECool);
    }
    void CoolStop()
    {
        IECool = Cool();
        StopCoroutine(IECool);
    }

    IEnumerator Cool()
    {
        yield return new WaitForSeconds(delay);
        IECool = null;
    }


}

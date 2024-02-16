using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : EnemyManage, IMove, IMBreak
{

    [SerializeField] float jumpSpeed;
    [SerializeField] float delay;
    [SerializeField] float speed;

    [SerializeField] GameObject physics;

    public void Move()
    {
        StartJump();
        GroundCheck();
    }

    public void MBreak()
    {
        //StopJump();
    }

    IEnumerator IEJump;

    void StartJump()
    {
        if (IEJump == null)
        {
            IEJump = EJump();
            StartCoroutine(IEJump);
        }
    }
    void StopJump()
    {
        if (IEJump != null)
        {
            StopCoroutine(IEJump);
            IEJump = null;
        }
    }

    IEnumerator EJump()
    {
        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        if (PlayerManage.Instance.PlayerPosition().x > transform.position.x)
        {
            rigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(delay);
        IEJump = null;

    }

    void GroundCheck()
    {
        Vector2 pos = transform.position;
        Vector2 size = physics.GetComponent<BoxCollider2D>().size;
        Vector2 offset = physics.GetComponent<BoxCollider2D>().offset;
        Vector2 left = pos + offset - new Vector2(size.x / 2, size.y / 2) + new Vector2(0.1f, 0f);
        Vector2 right = pos + offset - new Vector2(- size.x / 2, (size.y / 2) + 0.05f) - new Vector2(0.1f, 0f);
        Collider2D col = Physics2D.OverlapArea(left, right, LayerMask.GetMask("Platform"));
        if (col == null)
        {
            AnimSetTrue("IsJump");
        }
        else
        {
            AnimSetTrue("IsIdle");
        }
    }
}

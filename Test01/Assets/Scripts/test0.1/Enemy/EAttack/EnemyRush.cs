using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRush : EnemyManage, IAttack
{

    [SerializeField] float speed;
    [SerializeField] float delay;

    bool isRight;

    RaycastHit2D rayHit;
    Vector2 rayPos;

    public void Attack()
    {
        if (IERush == null)
        {
            RushStart();
        }
    }

    IEnumerator IERush;
    void RushStart()
    {
        rayPos = transform.position;
        rayHit = Physics2D.Raycast(rayPos, Vector3.left, 0f, LayerMask.GetMask("Platform"));
        if (transform.position.x < PlayerManage.Instance.PlayerPosition().x)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        IERush = Rush();
        StartCoroutine(IERush);
    }
    void RushStop()
    {
        if (IERush != null)
        {
            StopCoroutine(IERush);
            IERush = null;
        }
    }

    IEnumerator Rush()
    {
        while (rayHit.collider == null)
        {
            AnimSetTrue("IsAttack");
            rayPos = transform.position + new Vector3(0f, -0.2f, 0f);
            if (isRight)
            {
                rayHit = Physics2D.Raycast(rayPos, Vector3.left, -1f, LayerMask.GetMask("Platform"));
                rigid.velocity = new Vector2(1f * speed, rigid.velocity.y);
                transform.localScale = new Vector2(1f, 1f);
            }
            else
            {
                rayHit = Physics2D.Raycast(rayPos, Vector3.left, 1f, LayerMask.GetMask("Platform"));
                rigid.velocity = new Vector2(-1f * speed, rigid.velocity.y);
                transform.localScale = new Vector2(-1f, 1f);
            }
            yield return null;

        }
        if (isRight)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(new Vector2(-3f, 3f), ForceMode2D.Impulse);
        }
        else
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(new Vector2(3f, 3f), ForceMode2D.Impulse);
        }
        AnimSetFalse("IsAttack");
        yield return new WaitForSeconds(delay);
        IERush = null;
        
    }
}

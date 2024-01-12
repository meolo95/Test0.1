using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRush : MonoBehaviour, IAttack
{
    Rigidbody2D rigid;

    [SerializeField] float speed;
    [SerializeField] float delay;

    bool isRight;

    RaycastHit2D rayHit;
    Vector2 rayPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.DrawRay(rayPos, Vector3.left);
    }

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
        if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
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
        IERush = Rush();
        StopCoroutine(IERush);
    }

    IEnumerator Rush()
    {
        while (rayHit.collider == null)
        {
            rayPos = transform.position;
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
        yield return new WaitForSeconds(delay);
        IERush = null;
        
    }
}

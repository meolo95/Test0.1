using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRushJump : MonoBehaviour, IAttack
{
    Rigidbody2D rigid;

    [SerializeField] float speed;
    [SerializeField] float delay;
    [SerializeField] float jumpSpeed;

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
        RushJump();
        Jump();
    }

    void RushJump()
    {
        rayPos = transform.position;
        if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
        {
            rigid.AddForce(new Vector2(speed * -0.02f, 0f), ForceMode2D.Impulse);
            rayHit = Physics2D.Raycast(rayPos, Vector3.left, 3f, LayerMask.GetMask("Platform"));
            if (rigid.velocity.x < -1 * speed)
            {
                rigid.velocity = new Vector2(-1 * speed, rigid.velocity.y);
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (PlayerLocation.Instance.PlayerPosition().x > transform.position.x)
        {
            rigid.AddForce(new Vector2(speed * 0.02f, 0f), ForceMode2D.Impulse);
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

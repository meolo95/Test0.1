using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BoarManMove : MonoBehaviour
{
    NotFall notFall;
    NotBlocked notBlocked;
    public Animator anim;
    public Rigidbody2D rigid;
    Enemy enemy;
    [SerializeField] float moveSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed;
    

    public bool isSense;
    int rand;
    bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        notFall = GetComponent<NotFall>(); 
        notBlocked = GetComponent<NotBlocked>();
        StartRand();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (enemy.isAlive)
        {
            BMMove();
        }
        if (enemy.isAlive == false)
        {
            StopAllCoroutines();
        }

        if (isSense == true && enemy.isAlive == true)
        {
            Running();
            Jump();
        }
        
        if(enemy.isHit)
        {
            isSense = true;
        }


    }

    void BMMove()
    {
        if (isSense == false)
        {
            if (notFall.Catch() == 1)
            {
                rand = -1;
            }
            if (notFall.Catch() == -1)
            {
                rand = 1;
            }
            rigid.velocity = new Vector2(rand * moveSpeed, rigid.velocity.y);
            if (Mathf.Abs(rand) >= 1)
            {
                anim.SetBool("IsWalk", true);
                anim.SetBool("IsIdle", false);
                if (rand == 1)
                {
                    transform.localScale = new Vector3(1, 1, 1);

                }
                if (rand == -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else if (rand == 0)
            {
                anim.SetBool("IsIdle", true);
                anim.SetBool("IsWalk", false);
            }
        }
    }

    IEnumerator SMove;
    void StartRand()
    {
        SMove = Move();
        StartCoroutine(Move());
    }
    void StopRand()
    {
        SMove = Move();
        StopCoroutine(Move());
    }

    IEnumerator Move()
    {

        while (isSense == false)
        {
            rand = Random.Range(-1, 2);
            float time = Random.Range(1f, 3f);
            yield return new WaitForSeconds(time);
        }

    }

    void Running()
    {
        anim.SetBool("IsRun", true);
        if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
        {
            rigid.AddForce(new Vector2(-0.6f, 0f), ForceMode2D.Impulse);
            if (rigid.velocity.x < -1 * runSpeed)
            {
                rigid.velocity = new Vector2(-1 * runSpeed, rigid.velocity.y);
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (PlayerLocation.Instance.PlayerPosition().x > transform.position.x)
        {
            rigid.AddForce(new Vector2(0.6f, 0f), ForceMode2D.Impulse);
            if (rigid.velocity.x > 1 * runSpeed)
            {
                rigid.velocity = new Vector2(1 * runSpeed, rigid.velocity.y);
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
    void Jump()
    {
        if (notBlocked.Catch() != 0 && isJump == false)
        {
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJump = true;
            StopCo();
            StartCo();
        }
    }

    IEnumerator jumpco;

    void StartCo()
    {
        jumpco = JumpCool();
        StartCoroutine(jumpco);
    }

    void StopCo()
    {
        jumpco = JumpCool();
        StopCoroutine(jumpco);
    }

    IEnumerator JumpCool()
    {
        yield return new WaitForSeconds(0.5f);
        isJump = false;
    }


}

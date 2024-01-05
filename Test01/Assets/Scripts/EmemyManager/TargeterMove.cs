using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargeterMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float attackDelay;

    [SerializeField] public GameObject targeter;
    [SerializeField] bool isMage;
    

    Throw thrower;
    Enemy enemy;
    NotFall notFall;
    public Rigidbody2D rigid;
    public Animator anim;

    Vector3 playerPos;
    private float dev;
    Vector2 pos;
    int rand;
    public bool isTarget = false;
    public bool isReady = false;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        //spearGoblin = GetComponent<SpearGoblin>();
        rigid = GetComponent<Rigidbody2D>();
        //spearGoblinThrow = GetComponent<SpearGoblinThrow>();
        notFall = GetComponent<NotFall>();
        anim = GetComponent<Animator>();
        thrower = GetComponent<Throw>();

        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAlive)
        {
            TargetMove();
        }
        if (enemy.isAlive == false)
        {
            StopAllCoroutines();
        }

    }

    private void FixedUpdate()
    {

    }

    void TargetMove()
    {
        if (isTarget == false && isReady == false)
        {
            StopCo();
            if (notFall.Catch() == 1)
            {
                rand = -1;
            }
            if (notFall.Catch() == -1)
            {
                rand = 1;
            }
            rigid.velocity = new Vector2(rand * moveSpeed, rigid.velocity.y);
            anim.SetBool("IsAttack", false);
            anim.SetBool("IsReady", false);
            if (Mathf.Abs(rand) >= 1)
            {
                anim.SetBool("IsRun", true);
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
                anim.SetBool("IsRun", false);
            }
        }
        else if (isTarget == true && isReady == true)
        {
            isTarget = false;

            StarCo();


        }
    }

    public void GetTarget()
    {
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition();
        dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y - transform.position.y, 2));
        pos = new Vector2((playerPos.x - transform.position.x) / dev, (playerPos.y - transform.position.y) / dev);
    }

    IEnumerator throwcoroutine;

    void StarCo()
    {
        throwcoroutine = Targeting();
        StartCoroutine(throwcoroutine);
    }

    void StopCo()
    {
        if (throwcoroutine != null)
        {
            StopCoroutine(throwcoroutine);
        }

    }

    IEnumerator Targeting()
    {
        while (isReady)
        {
            ChangeDirection();
            anim.SetBool("IsRun", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsReady", true);
            anim.SetBool("IsAttack", false);
            yield return new WaitForSeconds(attackDelay);
            if (isReady)
            {
                anim.SetBool("IsAttack", true);
                anim.SetBool("IsReady", false);

                if (isMage)
                {
                    thrower.ThrowBall();
                }
                if (isMage == false)
                {
                    thrower.ThrowObject();
                }
                
                
            }
            yield return new WaitForSeconds(0.2f);
        }


    }



    IEnumerator Move()
    {

        while (isTarget == false)
        {
            rand = Random.Range(-1, 2);
            float time = Random.Range(1f, 3f);
            yield return new WaitForSeconds(time);
        }

    }

    void ChangeDirection()
    {
        playerPos = PlayerLocation.Instance.PlayerPosition();

        if (playerPos.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

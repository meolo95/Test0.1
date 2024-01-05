using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class SwordGoblin : MonoBehaviour
{
    [SerializeField] GameObject hitZone;
    [SerializeField] GameObject hitByP;
    [SerializeField] float moveSpeed;
    public Enemy enemy;
    public Rigidbody2D rigid;
    NotFall notFall;
    public Animator anim;
    public bool isShield;
    public bool isCool;
    int rand;
    public bool isTarget;
    public bool isSense;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        notFall = GetComponent<NotFall>();

        StartRand();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShield)
        {
            hitZone.GetComponent<Health>().Shielding = true;

        }
        else
        {
            hitZone.GetComponent<Health>().Shielding = false;
        }

        if (enemy.isAlive)
        {
            ShielderMove();
        }
        if (enemy.isAlive == false)
        {
            StopAllCoroutines();
            isShield = false;
        }

        
    }

    void ShielderMove()
    {
        if (isShield == false && isSense == false)
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

        while (isShield == false)
        {
            rand = Random.Range(-1, 2);
            float time = Random.Range(1f, 3f);
            yield return new WaitForSeconds(time);
        }

    }


    IEnumerator CoShield;

    public void StartCo()
    {
        if (enemy.isAlive)
        {
            CoShield = Shielding();
            StartCoroutine(CoShield);
        }
    }
    public void StopCo()
    {
        CoShield = Shielding();
        StopCoroutine(CoShield);
    }

    IEnumerator Shielding()
    {
        UpShield();
        StopRand();
        if (PlayerLocation.Instance.PlayerPosition().x > transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        yield return new WaitForSeconds(0.75f);
        DownShield();
    }

    void UpShield()
    {
        anim.SetBool("IsShield", true);
        isShield = true;
        isCool = true;
        rigid.velocity = Vector3.zero;
    }

    public void DownShield()
    {
        anim.SetBool("IsShield", false);
        isShield = false;
        StartCoroutine(CoolTime());
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.5f);
        StartRand();
        isCool = false;
    }
}

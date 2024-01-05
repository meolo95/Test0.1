using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalk : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Enemy enemy;
    Animator anim;
    public NotFall notFall;
    public Rigidbody2D rigid;
    int rand;
    public bool isTarget = false;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        notFall = GetComponent<NotFall>();
        anim = GetComponent<Animator>();

        StartCoroutine(SpiderMove());
        
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
        if (isTarget && enemy.isAlive)
        {
            TargetUnderMove();
            
        }
        
    }

    private void FixedUpdate()
    {

    }

    void TargetMove()
    {
        if (isTarget == false)
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
                if (rand == 1)
                {
                    anim.SetBool("IsWalk", true);
                    transform.localScale = new Vector3(1, -1, 1);

                }
                if (rand == -1)
                {
                    anim.SetBool("IsWalk", true);
                    transform.localScale = new Vector3(-1, -1, 1);
                }
            }
            else if (rand == 0)
            {
                anim.SetBool("IsWalk", false);
            }
        }
    }

    void TargetUnderMove()
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
                if (rand == 1)
                {
                anim.SetBool("IsWalk", true);
                transform.localScale = new Vector3(1, 1, 1);

                }
                if (rand == -1)
                {

                anim.SetBool("IsWalk", true);
                transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else if (rand == 0)
            {
            anim.SetBool("IsWalk", false);
        }
    }




    IEnumerator SpiderMove()
    {

        while (isTarget == false)
        {
            rand = Random.Range(-1, 2);
            float time = Random.Range(1f, 3f);
            yield return new WaitForSeconds(time);
        }

    }
}

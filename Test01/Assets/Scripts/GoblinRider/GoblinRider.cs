using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRider : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigid;
    public Animator anim;

    [SerializeField] float moveSpeed;
    Enemy enemy;

    [SerializeField] GameObject meleeGoblin;

    public bool isColl;
    public bool isRight;
    public bool isRushing = false;

    public bool isTarget = false;
    bool isSummon = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAlive == false && isSummon == false)
        {
            StartCoroutine(SummonGoblin());
            isSummon = true;

        }
    }

    void MoveToPlayer()
    {
        if (isRight == true)
        {
            rigid.velocity = new Vector2(1f * moveSpeed, rigid.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (isRight == false)
        {
            rigid.velocity = new Vector2(-1f * moveSpeed, rigid.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    
    IEnumerator SummonGoblin()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(meleeGoblin, transform.position, Quaternion.identity);
    }


    IEnumerator Moving;
    public void StartCo()
    {
        Moving = MoveTo();
        StartCoroutine(MoveTo());
    }

    public void StopCo()
    {
        Moving = MoveTo();
        StopCoroutine(MoveTo());
    }


    IEnumerator MoveTo()
    {

        isRushing = true;
        while (isColl == false)
        {
            anim.SetBool("IsRush", true);
            if (enemy.isAlive)
            {
                if (isRight == true)
                {
                    rigid.velocity = new Vector2(1f * moveSpeed, rigid.velocity.y);
                    transform.localScale = new Vector2(1f, 1f);
                }
                else if (isRight == false)
                {
                    rigid.velocity = new Vector2(-1f * moveSpeed, rigid.velocity.y);
                    transform.localScale = new Vector2(-1f, 1f);
                }
            }
            yield return null;
        }
        Debug.Log("Check");
    }
}

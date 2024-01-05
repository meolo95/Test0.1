using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Boar : MonoBehaviour
{

    public Rigidbody2D rigid;
    public Animator anim;

    [SerializeField] float moveSpeed;
    Enemy enemy;

    // Start is called before the first frame update

    public bool isTarget = false;
    public bool isRight = false;
    public bool isColl = false;
    public bool isRushing = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAlive == true)
        {
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


    public void StartCo()
    {
        StartCoroutine(MoveTo());
    }

    public void StopCo()
    {
        StopCoroutine(MoveTo());
    }

    IEnumerator MoveToP()
    {

        while (isColl == false)
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

        yield return new WaitForSeconds(0.1f);
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

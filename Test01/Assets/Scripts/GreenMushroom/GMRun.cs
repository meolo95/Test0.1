using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GMRun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigid;
    public Animator anim;
    Enemy enemy;
    NotBlocked notBlocked;

    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    public bool isJump = false;


    public bool isTarget;
    public bool isOn = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        notBlocked = GetComponent<NotBlocked>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOn)
        {
            if (enemy.isAlive == true)
            {
                StartChasing();
                if (isTarget)
                {
                    Jump();
                }
            }
            if (enemy.isAlive == false)
            {
                StopAllCoroutines();
            }
        }
    }

    public void StartChasing()
    {
        if (isTarget == true)
        {
            anim.SetBool("IsRun", true);
            if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
            {
                rigid.AddForce(new Vector2(-0.4f, 0f), ForceMode2D.Impulse);
                if (rigid.velocity.x < -1 * speed)
                {
                    rigid.velocity = new Vector2(-1 * speed, rigid.velocity.y);
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (PlayerLocation.Instance.PlayerPosition().x > transform.position.x)
            {
                rigid.AddForce(new Vector2(0.4f, 0f), ForceMode2D.Impulse);
                if (rigid.velocity.x > 1 * speed)
                {
                    rigid.velocity = new Vector2(1 * speed, rigid.velocity.y);
                }
                transform.localScale = new Vector3(1, 1, 1);
            }
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

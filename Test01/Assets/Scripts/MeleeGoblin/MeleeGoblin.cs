using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGoblin : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    Enemy enemy;
    NotFall notFall;
    [SerializeField] float moveSpeed;
    [SerializeField] float waitTime;

    [SerializeField] GameObject attackZone;

    // Start is called before the first frame update

    public bool isTarget = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        notFall = GetComponent<NotFall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAlive == false)
        {
            attackZone.SetActive(false);
        }

        if (notFall.Catch() == 1)
        {
            rigid.AddForce(Vector2.left, ForceMode2D.Impulse);
        }
        if (notFall.Catch() == -1)
        {
            rigid.AddForce(Vector2.right, ForceMode2D.Impulse);
        }
    }

    void MoveToPlayer()
    {
        if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
        {
            rigid.AddForce(new Vector2(1f * moveSpeed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x)
        {
            rigid.AddForce(new Vector2(-1f * moveSpeed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    IEnumerator Mover;
    public void StartCo()
    {
        Mover = MoveTo();
        StartCoroutine(Mover);
    }

    public void StopCo()
    {
        Mover = MoveTo();
        StopCoroutine(Mover);
    }

    IEnumerator MoveTo()
    {
        if (enemy.isAlive)
        {

            anim.SetBool("IsAttack", true);
            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x && notFall.Catch() != 1)
            {
                rigid.AddForce(new Vector2(1f * moveSpeed, 0f), ForceMode2D.Impulse);
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x && notFall.Catch() != -1)
            {
                rigid.AddForce(new Vector2(-1f * moveSpeed, 0f), ForceMode2D.Impulse);
                transform.localScale = new Vector2(-1f, 1f);
            }
        }
        if (enemy.isAlive)
        {
            attackZone.SetActive(true);

        }

        yield return new WaitForSeconds(1f);
        attackZone.SetActive(false);


        anim.SetBool("IsAttack", false);
        yield return new WaitForSeconds(1f);
        rigid.velocity = Vector2.zero;
        isTarget = false;
    }

}

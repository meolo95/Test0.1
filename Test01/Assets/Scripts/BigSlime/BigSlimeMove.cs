using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random as UnityEngine.Random;

public class BigSlimeMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject slime;


    Enemy enemy;
    Rigidbody2D rigid;
    bool isJumping = false;
    public bool isTarget = false;
    bool isSum = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAlive)
        {
            BigMove();
        }
        if (enemy.isAlive == false && isSum == true)
        {
            for (int i = 0; i < 3; i++)
            {
                float rand = Random.Range(0f, 3f);
                Vector3 sumpos = transform.position;
                sumpos.x += rand;
                GameObject enemyObject = Instantiate(slime, sumpos, Quaternion.identity);

                isSum = false;
            }
        }
    }

    void BigMove()
    {
        if (isTarget && enemy.isHit == false)
        {
            if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x)
            {
                rigid.velocity = new Vector2(-1, rigid.velocity.y) * moveSpeed;
            }
            else if (transform.position.x <  PlayerLocation.Instance.PlayerPosition().x)
            {
                rigid.velocity = new Vector2(1, rigid.velocity.y) * moveSpeed;
            }
        }
        else if (isTarget == false && enemy.isHit == false)
        {
            rigid.velocity = Vector3.zero;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            enemy.isHit = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    //Rigidbody2D rigid;
    public Animator slimeAnim;

    [SerializeField] float jumpSpeed;
    [SerializeField] float speed;
    Rigidbody2D rigid;

    public Enemy enemy;

    public bool follow = false;
    //public float lasttime;
    [SerializeField] public float delay;
    public bool isground;
    Vector3 pos;
    public bool readytojump;

    public bool isJumping = false;



    //[SerializeField] public float stun;
    // Start is called before the first frame update
    void Start()
    {

        enemy = GetComponent<Enemy>();
        slimeAnim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        //target = player.transform;

        //player = GetComponent<GameObject>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        JumpAnima();


    }

    void Update()
    {

    }


    public void SlimeJump()
    {
        if (readytojump && enemy.isAlive)
        {
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            GetTarget();
            
            if (follow)
            {
                if (pos.x > transform.position.x)
                {
                    rigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                    //enemy.rigid.velocity = new Vector2(1 * speed, enemy.rigid.velocity.y);
                }
                else
                {
                    rigid.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                    //enemy.rigid.velocity = new Vector2(-1 * speed, enemy.rigid.velocity.y);
                }
            }
        isground = false;
        }
    }







    public void GetTarget()
    {
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition();
        pos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
    }

    void JumpAnima()
    {
        Vector3 raypos1 = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        Vector3 raypos2 = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);

        if (rigid.velocity.y > 0.1f)
        {
            slimeAnim.SetBool("IsJumping", true);
            slimeAnim.SetBool("IsIdle", false);
            slimeAnim.SetBool("IsFalling", false);
        }
        else if (rigid.velocity.y < -0.1f)
        {
            slimeAnim.SetBool("IsJumping", false);
            slimeAnim.SetBool("IsIdle", false);
            slimeAnim.SetBool("IsFalling", true);
        }
        else
        {
            RaycastHit2D rayhit1 = Physics2D.Raycast(raypos1, Vector3.down, 1, LayerMask.GetMask("Platform"));
            RaycastHit2D rayhit2 = Physics2D.Raycast(raypos2, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayhit1.collider != null || rayhit2.collider != null)
            {

                slimeAnim.SetBool("IsJumping", false);
                slimeAnim.SetBool("IsIdle", true);
                slimeAnim.SetBool("IsFalling", false);
            }
        }
    }

    public void DestroyEnemy()
    {

        slimeAnim.SetBool("IsDie", true);
        enemy.HitZone.SetActive(false);
        enemy.isAlive = false;
        Destroy(gameObject, 2f);
    }
}



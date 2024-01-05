using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class BowGoblinMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float attackDelay;
    BowGoblin bowGoblin;
    BowGoblinThrow bowGoblinThrow;
    Enemy enemy;
    NotFall notFall;
    public Rigidbody2D rigid;
    Vector3 playerPos;
    private float dev;
    Vector2 pos;
    int rand;
    public bool isTarget = false;
    public bool isReady = false;
    bool isDrop = false;

    [SerializeField] GameObject dropArrow;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        bowGoblin = GetComponent<BowGoblin>();
        rigid = GetComponent<Rigidbody2D>();
        bowGoblinThrow = GetComponent<BowGoblinThrow>();
        notFall = GetComponent<NotFall>();

        StartCoroutine(GoblinMove());
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
            if (isDrop == false)
            {
                GameObject droper = Instantiate(dropArrow, transform.position, Quaternion.identity);
                droper.GetComponent<BlockedArrow>().isDrop = true;
                droper.GetComponent<BlockedArrow>().num = 3;
                isDrop = true;
            }
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
            bowGoblin.bowGoblinAnim.SetBool("IsAttack", false);
            bowGoblin.bowGoblinAnim.SetBool("IsReady", false);
            if (Mathf.Abs(rand) >= 1)
            {
                bowGoblin.bowGoblinAnim.SetBool("IsRun", true);
                bowGoblin.bowGoblinAnim.SetBool("IsIdle", false);
                if (rand ==1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    
                }
                if (rand == -1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else if (rand ==0)
            {
                bowGoblin.bowGoblinAnim.SetBool("IsIdle", true);
                bowGoblin.bowGoblinAnim.SetBool("IsRun", false);
            }
        }
        else if (isTarget == true && isReady == true)
        {
            isTarget = false;

            StarCo();


        }
    }

    public void GoblinGetTarget()
    {
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition(); 
        dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y - transform.position.y, 2));
        pos = new Vector2((playerPos.x - transform.position.x) / dev, (playerPos.y - transform.position.y) / dev);
    }

    IEnumerator throwcoroutine;
    void StarCo()
    {
        throwcoroutine = GoblinTargeting();
        StartCoroutine(throwcoroutine);
    }
    
    void StopCo()
    {
        if (throwcoroutine != null)
        {
            StopCoroutine(throwcoroutine);
        }

    }

    IEnumerator GoblinTargeting()
    {
        while (isReady)
        {
            ChangeDirection();
            bowGoblin.bowGoblinAnim.SetBool("IsRun", false);
            bowGoblin.bowGoblinAnim.SetBool("IsIdle", false);
            bowGoblin.bowGoblinAnim.SetBool("IsReady", true);
            bowGoblin.bowGoblinAnim.SetBool("IsAttack", false);
            yield return new WaitForSeconds(attackDelay);
            if (isReady)
            {
                bowGoblin.bowGoblinAnim.SetBool("IsAttack", true);
                bowGoblin.bowGoblinAnim.SetBool("IsReady", false);
                bowGoblinThrow.ThrowArrow();
            }
            yield return new WaitForSeconds(0.1f);
        }

        
    }
    
    
    
    IEnumerator GoblinMove()
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

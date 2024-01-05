using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class SpearGoblinMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float attackDelay;
    SpearGoblin spearGoblin;
    SpearGoblinThrow spearGoblinThrow;
    Enemy enemy;
    NotFall notFall;
    public Rigidbody2D rigid;
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
        spearGoblin = GetComponent<SpearGoblin>();
        rigid = GetComponent<Rigidbody2D>();
        spearGoblinThrow = GetComponent<SpearGoblinThrow>();
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
            spearGoblin.spearGoblinAnim.SetBool("IsAttack", false);
            spearGoblin.spearGoblinAnim.SetBool("IsReady", false);
            if (Mathf.Abs(rand) >= 1)
            {
                spearGoblin.spearGoblinAnim.SetBool("IsRun", true);
                spearGoblin.spearGoblinAnim.SetBool("IsIdle", false);
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
                spearGoblin.spearGoblinAnim.SetBool("IsIdle", true);
                spearGoblin.spearGoblinAnim.SetBool("IsRun", false);
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
            spearGoblin.spearGoblinAnim.SetBool("IsRun", false);
            spearGoblin.spearGoblinAnim.SetBool("IsIdle", false);
            spearGoblin.spearGoblinAnim.SetBool("IsReady", true);
            spearGoblin.spearGoblinAnim.SetBool("IsAttack", false);
            yield return new WaitForSeconds(attackDelay);
            if (isReady)
            {
                spearGoblin.spearGoblinAnim.SetBool("IsAttack", true);
                spearGoblin.spearGoblinAnim.SetBool("IsReady", false);
                spearGoblinThrow.ThrowSpear();
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

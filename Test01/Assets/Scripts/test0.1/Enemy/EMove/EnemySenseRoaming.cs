using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySenseRoaming : EnemyManage, IMove
{
    private int rand;
    [SerializeField] float speed;
    public bool isSense;


    protected override void Awake()
    {
        base.Awake();
        RandomC();
    }

    public void Move()
    {
        if (!isSense)
        {
            switch (Catch())
            {
                case 1:
                    rand = -1;
                    break;
                case -1:
                    rand = 1;
                    break;
                case 0:

                    break;
            }
            rigid.velocity = new Vector2(rand * speed, rigid.velocity.y);
            if (rand != 0)
            {
                AnimSetTrue("IsWalk");
                transform.localScale = new Vector2(rand, 1f);
            }
            if (rand == 0)
            {
                AnimSetTrue("IsIdle");
            }
        }
        if (isSense)
        {
            AnimSetTrue("IsSense");
        }
        
    }

    void RandomC()
    {
        StartCoroutine(RandomDirection());

        IEnumerator RandomDirection()
        {

            int number = Random.Range(-1, 2);
            float time = Random.Range(1f, 3f);
            yield return new WaitForSeconds(time);
            rand = number;
            StartCoroutine(RandomDirection());

        }
    }

    public int Catch()
    {
        Vector3 raypos1 = new Vector3(transform.position.x + 0.4f, transform.position.y - 0.3f, transform.position.z);
        Vector3 raypos2 = new Vector3(transform.position.x - 0.4f, transform.position.y - 0.3f, transform.position.z);
        Debug.DrawRay(raypos1, Vector3.down);
        Debug.DrawRay(raypos2, Vector3.down);

        RaycastHit2D rayHit1 = Physics2D.Raycast(raypos1, Vector3.down, 1f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(raypos2, Vector3.down, 1f, LayerMask.GetMask("Platform"));
        if (rayHit1.collider == null && rayHit2.collider != null)
        {
            return 1;
        }
        if (rayHit2.collider == null && rayHit1.collider != null)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

}

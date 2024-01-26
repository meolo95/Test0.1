using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyRoaming : EnemyManage, IMove
{
    protected int rand;
    [SerializeField] protected float speed;
    protected BoxCollider2D box;
    protected override void Awake()
    {
        base.Awake();
        box = transform.GetChild(2).GetComponent<BoxCollider2D>();
        RandomC();
        
    }

    public void Move()
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

    int Catch()
    {
        Vector2 size = box.size;
        float x = (box.size.x / 2) + 0.2f;
        float y = (box.size.y / 2);
        Vector2 pos = transform.position;
        pos += box.offset;
        Vector2 posright = pos;
        Vector2 posleft = pos;
        posright.x += x;
        posleft.x -= x;
        posright.y = posleft.y -= (y - 0.5f);

        Vector3 raypos1 = new Vector3(posright.x, posright.y, transform.position.z);
        Vector3 raypos2 = new Vector3(posleft.x, posleft.y, transform.position.z);
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

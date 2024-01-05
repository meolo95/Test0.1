using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGTP : MonoBehaviour
{
    Enemy enemy;
    Rigidbody2D rigid;
    public Animator anim;

    public bool isTarget;
    float invisible = 1f;
    float timer = 0f;
    bool isMove;
    bool isAttackOver;

    public SpriteRenderer[] spriteRenderer;
    [SerializeField] GameObject[] parts;
    [SerializeField] GameObject attackZone;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i] = parts[i].GetComponent<SpriteRenderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget && isMove == false)
        {
            Teleport();
        }
        if (isMove == true)
        {
            Visible();
        }
        if (enemy.isAlive == false)
        {
            StopAllCoroutines();
            attackZone.SetActive(false);
        }
        
    }

    void Teleport()
    {
        
        timer += Time.deltaTime;
        invisible -=  0.33f * timer;
        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i].color = new Color(1f, 1f, 1f, invisible);
        }
        if (invisible < -3f)
        {
            anim.SetBool("IsAttack", true);
            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {
                Vector3 tPos = PlayerLocation.Instance.PlayerPosition();
                tPos.x += 4f;
                transform.localScale = new Vector3(-1f, 1f, 1f);
                transform.position = tPos;
            }
            else if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x)
            {
                Vector3 tPos = PlayerLocation.Instance.PlayerPosition();
                tPos.x -= 4f;
                transform.localScale = new Vector3(1f, 1f, 1f);
                transform.position = tPos;
            }
            isMove = true;
            timer = 0f;
            
        }
    }

    void Visible()
    {
        timer += Time.deltaTime;
        invisible += 0.33f * timer;
        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i].color = new Color(1f, 1f, 1f, invisible);
        }
        if (isAttackOver == false)
        {
            isAttackOver = true;
            AttackStart();
        }
    }

    void AttackStart()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.6f);
        attackZone.SetActive(true);
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("IsAttack", false);
        yield return new WaitForSeconds(0.1f);
        attackZone.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isMove = false;
        timer = 0f;
        invisible = 1f;
        isAttackOver = false;
    }
    
}

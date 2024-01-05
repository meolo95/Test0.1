using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCSense : MonoBehaviour
{
    SCAttack scAttack;

    Rigidbody2D rigid;

    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;

    public bool isTarget;
    bool isAttack;
    bool isUp;
    Vector3 upPos;
    Vector3 downPos;
    // Start is called before the first frame update
    void Start()
    {
        downPos = transform.position;
        downPos.y -= 3f;
        scAttack = GetComponent<SCAttack>();
        rigid = GetComponent<Rigidbody2D>();
        upPos = transform.position + Vector3.up * 4.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (scAttack.enemy.isAlive)
        {
            if (PlayerLocation.Instance.PlayerPosition().x > transform.position.x)
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1f);
            }
            if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
            {
                transform.localScale = new Vector3(-1.3f, 1.3f, 1f);
            }
        }
        if (scAttack.enemy.isAlive == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPos, Time.deltaTime * 6f);
        }
        if (isTarget && isUp == false)
        {
            GetUp();
            if (isAttack == false)
            {
                scAttack.StartAttack();
                isAttack = true;
            }
            
        }

        if (transform.position == upPos)
        {
            isUp = true;
        }
    }

    public void GetUp()
    {

        StartCoroutine(Up());
        Light1.SetActive(true);
        Light2.SetActive(true);
    }

    IEnumerator Up()
    {
        transform.position = Vector3.MoveTowards(transform.position, upPos, Time.deltaTime * 12f);
        yield return null;
    }
}

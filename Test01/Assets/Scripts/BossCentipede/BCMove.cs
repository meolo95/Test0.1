using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCMove : MonoBehaviour
{
    [SerializeField] GameObject patrol;
    [SerializeField] float speed;
    [SerializeField] float chaseSpeed;

    Rigidbody2D rigid;
    public bool isTarget;

    bool isFir;
    bool isSec;

    bool down = true;
    bool up;

    [SerializeField] bool isMinus;
    [SerializeField] bool isY;

    Vector3 pos;
    Vector3 nextPos;
    public Vector3 playerPos;
    public Vector3 thisPos;

    bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pos = transform.position;
        nextPos = patrol.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isY)
        {
            if (isTarget == false)
            {
                if (transform.position.y <= pos.y)
                {
                    isFir = true;
                    isSec = false;
                }
                if (transform.position.y >= nextPos.y)
                {
                    isSec = true;
                    isFir = false;
                }
                if (isFir)
                {
                    Patrol1();
                }
                if (isSec)
                {
                    Patrol2();
                }
            }
        }
        if (isY != true)
        {
            if (isTarget == false)
            {
                if (transform.position.x <= pos.x)
                {
                    isFir = true;
                    isSec = false;
                }
                if (transform.position.x >= nextPos.x)
                {
                    isSec = true;
                    isFir = false;
                }
                if (isFir)
                {
                    Patrol1();
                }
                if (isSec)
                {
                    Patrol2();
                }
            }
        }

        if (isTarget == true)
        {
            if (down == true)
            {
                Chase();
            }
            if (transform.position.y < playerPos.y)
            {
                down = false;
                Stop();
                if (check)
                {
                    StartCoroutine(cool());
                    Debug.Log("Check1");
                }
            }
            if (up == true)
            {
                Debug.Log("Check2");
                Back();
            }


        }
    }

    void Patrol1()
    {
        //transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);

        rigid.velocity = (nextPos - transform.position).normalized * speed;

        if (isMinus == true)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    void Patrol2()
    {
        //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

        rigid.velocity = (pos - transform.position).normalized * speed;

        if (isMinus == true)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
    }

    void Chase()
    {
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, Time.deltaTime * chaseSpeed);
        rigid.velocity = (playerPos - transform.position).normalized * chaseSpeed;
    }

    void Stop()
    {
        rigid.velocity = Vector2.zero;
    }

    void Back()
    {
        if (transform.position.y < thisPos.y)
        {
            rigid.velocity = (thisPos - transform.position).normalized * chaseSpeed;
        }
        if (transform.position.y > thisPos.y)
        {
            rigid.velocity = Vector2.zero;
        }
    }



    public void StartCo()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        up = false;
        down = true;
        check = true;
        isTarget = false;
        
    }

    IEnumerator cool()
    {
        check = false;
        yield return new WaitForSeconds(2f);
        up = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 pos;
    Vector3 nextPos;

    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float speed;

    Vector2 dir;

    bool check = true;

    bool isPos;
    bool isDown;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pos = transform.position;
        nextPos = pos;
        nextPos.x += x;
        nextPos.y += y;

        dir = (nextPos - pos).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos)
        {
            isDown = false;
            if (check)
            {
                StartCoroutine(Wait2());
            }
        }
        if (transform.position == nextPos)
        {
            isPos = false;
            if (check)
            {
                StartCoroutine(Wait1());
            }
        }

        if (isPos == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * speed);


            //rigid.velocity = new Vector2(dir.x * speed, dir.y * speed);
        }
        if (isDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);

            //rigid.velocity = new Vector2(-dir.x * speed, -dir.y * speed);
        }
    }

    IEnumerator Wait1()
    {
        check = false;
        yield return new WaitForSeconds(2f);
        isDown = true;
        yield return new WaitForSeconds(1f);
        check = true;
    }

    IEnumerator Wait2()
    {
        check = false;
        yield return new WaitForSeconds(2f);
        isPos = true;
        yield return new WaitForSeconds(1f);
        check = true;
    }

}




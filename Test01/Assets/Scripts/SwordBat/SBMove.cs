using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SBMove : MonoBehaviour
{
    [SerializeField] float range;
    Vector3 firstPos;
    Vector3 SecPos;

    [SerializeField] float speed;
    [SerializeField] bool isMinus;
    bool isFir;
    bool isSec;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
        SecPos = transform.position;
        SecPos.x += range;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == firstPos)
        {
            isFir = true;
            isSec = false;
        }
        if (transform.position == SecPos)
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

    void Patrol1()
    {
        transform.position = Vector3.MoveTowards(transform.position, SecPos, Time.deltaTime * speed);
        if (isMinus == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Patrol2()
    {
        transform.position = Vector3.MoveTowards(transform.position, firstPos, Time.deltaTime * speed);

        if (isMinus == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

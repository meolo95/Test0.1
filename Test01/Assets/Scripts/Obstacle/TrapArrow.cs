using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapArrow : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] bool isRight;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            rigid.velocity = Vector3.right * speed;
        }
        else
        {
            rigid.velocity = Vector3.left * speed;
        }

    }


}

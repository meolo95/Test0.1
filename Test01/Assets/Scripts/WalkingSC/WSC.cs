using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSC : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] float speed;
    [SerializeField] GameObject target;
    bool isRight;

    Vector2 pos;
    Vector2 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pos = transform.position;
        nextPos = target.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Walking();
    }

    void Walking()
    {
        if (transform.position.x < pos.x)
        {
            isRight = true;
        }
        else if (transform.position.x > nextPos.x)
        {
            isRight = false;
        }

        if (isRight == true)
        {
            rigid.velocity = Vector2.right * speed;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            rigid.velocity = Vector2.left * speed;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
    }
}

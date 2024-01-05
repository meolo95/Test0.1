using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {
        rigid=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingOn();

        if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (PlayerLocation.Instance.PlayerPosition().x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void MovingOn()
    {
        Vector3 dir = (PlayerLocation.Instance.PlayerPosition() - transform.position).normalized;
        rigid.velocity = dir * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : MonoBehaviour, IRotable
{
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotable();
    }

    public void Rotable()
    {
        transform.right = rigid.velocity;
    }
}

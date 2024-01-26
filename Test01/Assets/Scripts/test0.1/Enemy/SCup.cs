using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCup : MonoBehaviour
{
    bool isTarget;
    bool stop;
    Vector3 upPos;
    [SerializeField] float speed = 1f;
    EnemyBehavior behavior;
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    private void Awake()
    {
        behavior = GetComponentInParent<EnemyBehavior>();
        behavior.isDevine = true;
        upPos = transform.parent.position + new Vector3(0f, 4.5f, 0f);
    }

    private void Update()
    {
        if (isTarget && !stop)
        {
            Up();
        }
        if (transform.parent.position == upPos)
        {
            stop = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTarget = true;
            behavior.isDevine = false;
            Light1.SetActive(true);
            Light2.SetActive(true);
        }
    }

    void Up()
    {
        transform.parent.position = Vector3.MoveTowards(transform.position, upPos, Time.deltaTime * 12f);
    }
}

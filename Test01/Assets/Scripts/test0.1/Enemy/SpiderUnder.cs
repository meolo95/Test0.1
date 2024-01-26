using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderUnder : MonoBehaviour
{
    Rigidbody2D rigid;
    EnemyBehavior behavior;

    private void Awake()
    {
        
        rigid = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        behavior = GetComponentInParent<EnemyBehavior>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rigid.gravityScale = 1f;
            behavior.state = EnemyState.moving;
            gameObject.SetActive(false);
        }
    }
}

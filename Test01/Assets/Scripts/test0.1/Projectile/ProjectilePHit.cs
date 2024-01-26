using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePHit : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

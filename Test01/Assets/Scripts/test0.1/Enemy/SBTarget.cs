using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBTarget : MonoBehaviour
{
    EnemyBehavior behavior;

    private void Awake()
    {
        behavior = GetComponentInParent<EnemyBehavior>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Targeting()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            behavior.state = EnemyState.moving;
        }
    }
}

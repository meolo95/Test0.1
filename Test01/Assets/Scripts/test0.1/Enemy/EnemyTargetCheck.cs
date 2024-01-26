using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetCheck : MonoBehaviour, ITargeting
{
    EnemyBehavior behavior;
    [SerializeField] bool isEndless;

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
            behavior.state = EnemyState.targeting;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            behavior.state = EnemyState.targeting;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isEndless)
            {
                behavior.state = EnemyState.moving;
            }
        }
        
    }
}

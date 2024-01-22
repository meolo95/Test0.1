using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{

    private void Awake()
    {
        EnemyBehavior behavior = new EnemyBehavior();
        EnemyThrow enemyThrow = new EnemyThrow();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

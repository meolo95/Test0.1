using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropMob : EnemyFlyPatrol, IEtc
{
    GameObject drop;
    EnemyBehavior behavior;
    protected override void Awake()
    {
        base.Awake();
        behavior = GetComponentInChildren<EnemyBehavior>();
        drop = behavior.gameObject;
    }
    public void Etc()
    {
        if (drop != null)
        {
            drop.transform.position = transform.position + Vector3.down;
        }
        Move();
    }
}

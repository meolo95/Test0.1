using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStraight : StraightPro
{
    [SerializeField] float rotate = 90f;
    protected override void Awake()
    {
        base.Awake();
        float angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotate);
    }

    protected override void Update()
    {
        base.Update();
    }
}

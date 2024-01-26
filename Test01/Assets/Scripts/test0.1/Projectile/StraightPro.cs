using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPro : PProjectile
{
    protected Vector3 direction;
    protected override void Awake()
    {
        base.Awake();
        Move();
    }

    protected virtual void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    protected override void Move()
    {
        float dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y - transform.position.y, 2));
        direction = new Vector2((playerPos.x - transform.position.x) / dev, (playerPos.y - transform.position.y) / dev);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParabolaPro : PProjectile
{
    float xDistance;
    float yDistance;
    float gravity;
    float xSpeed;
    [SerializeField] float ySpeed;
    float xTime;
    float yTime;
    
    protected override void Awake()
    {
        base.Awake();
        Move();
    }

    protected override void Move()
    {
        base.Move();
        xDistance = playerPos.x - transform.position.x;
        yDistance = Mathf.Abs(playerPos.y - transform.position.y);
        gravity = 20;
        float timeToTop = ySpeed / gravity;
        float maxY = transform.position.y + (ySpeed * timeToTop) - (0.5f * gravity * timeToTop * timeToTop);
        float maxYDistance = Mathf.Abs(playerPos.y - maxY);
        yTime = Mathf.Sqrt(2 * maxYDistance / gravity) + timeToTop;
        xSpeed = xDistance / yTime;
        rigid.AddForce(new Vector2(xSpeed, ySpeed), ForceMode2D.Impulse);
    }

}

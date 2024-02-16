using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotable
{
    void Rotable();
}
public class PProjectile : Pooler
{
    protected Rigidbody2D rigid;
    protected Animator anim;
    [SerializeField] protected float speed;

    protected Vector3 playerPos;
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        playerPos = PlayerManage.Instance.PlayerPosition();
    }

    protected virtual void Move()
    {
    }

}

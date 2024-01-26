using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotable
{
    void Rotable();
}
public class PProjectile : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected Animator anim;
    [SerializeField] protected float speed;

    protected Vector3 playerPos;
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerPos = PlayerManage.Instance.PlayerPosition();
    }

    protected virtual void Move()
    {
    }

}

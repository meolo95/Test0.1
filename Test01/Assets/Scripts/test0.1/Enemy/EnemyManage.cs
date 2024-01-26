using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;


public interface IMove
{
    void Move();
}
public interface IAttack
{
    void Attack();
}
public interface ITargeting
{
    void Targeting();
}
public interface IHit
{
    void Hit();
}
public interface IDie
{
    void Die();
}
public interface IEtc
{
    void Etc();
}
public interface IBreak
{
    void Break();
}

public enum EnemyState
{
    moving,
    targeting,
    Etc
}

public enum EnemyHitState
{
    idle,
    hitting
}

public enum EnemyLife
{
    living,
    dying
}



public class EnemyManage : MonoBehaviour
{
    Animator anim;
    protected Rigidbody2D rigid;

    protected int isIdle;
    protected int isWalk;
    protected int isAttack;
    protected int isReady;
    protected int isDie;
    protected int isJump;
    int[] paint;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        paint = new int[anim.parameterCount];

        isIdle = Animator.StringToHash("IsIdle");
        isWalk = Animator.StringToHash("IsWalk");
        isAttack = Animator.StringToHash("IsAttack");
        isReady = Animator.StringToHash("IsReady");
        isDie = Animator.StringToHash("IsDie");
        isJump = Animator.StringToHash("IsJump");

        for (int i = 0; i < anim.parameterCount; i++)
        {
            paint[i] = Animator.StringToHash(anim.parameters[i].name);
        }
    }

    protected void AnimSetTrue(string name)
    {
        for (int i = 0; i < anim.parameterCount; i++)
        {
            if (anim.parameters[i].name != name)
            {
                anim.SetBool(paint[i], false);
            }
            else
            {
                anim.SetBool(paint[i], true);
            }
        }
    }

    protected void AnimSetFalse(string name)
    {
        anim.SetBool(name, false);
    }
}
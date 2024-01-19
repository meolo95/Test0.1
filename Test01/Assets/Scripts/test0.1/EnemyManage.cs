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
    hitting,
    idle
}

public enum EnemyLife
{
    living,
    dying
}



public class EnemyManage
{
    public string enemyname;
    public int health;
    public int demage;
    public int stun;
    public int speed;
    //EnemyState state;

    public EnemyManage(string name, int health, int demage, int stun, int speed)
    {
        this.enemyname = name;
        this.health = health;
        this.demage = demage;
        this.stun = stun;
        this.speed = speed;
    }
}
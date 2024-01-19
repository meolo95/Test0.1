using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IIdle
{
    void Idle();
}
public interface IWalk
{
    void Walk();
}
public interface IRoll
{
    void Roll();
}
public interface IJump
{
    void Jump();
}
public interface IHook
{
    void Hook();
}
public interface IDown
{
    void Down();
}
public interface IDraw
{
    void Draw();
}
public interface IMelee1
{
    void Melee1();
}
public interface IMelee2
{
    void Melee2();
}
public interface IUp
{
    void Up();
}


public enum PlayerState
{
    idle,
    walk,
    down,
    jump,
    melee,
    draw,
    hook,
    roll,
    hit,
    devine

}


public enum PlayerLife
{
    live,
    die
}

public static class PState { public static Dictionary<PlayerState, bool> states = new Dictionary<PlayerState, bool>(); }
public class PlayerManage
{
    protected int health;
    protected int arrow;
    protected float speed;
    protected float jump;

    protected int dir;

    protected Rigidbody2D rigid;

    protected PlayerLife life;


    public PlayerManage(int health, int arrow, float speed, float jump)
    {
        this.health = health;
        this.arrow = arrow;
        this.speed = speed;
        this.jump = jump;

        
    }

    public float GetSpeed()
    {
        return speed;
    }

}

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
public interface IMelee
{
    void Melee();
}


public enum PlayerKeyDownCommand
{
    idle,
    walkL,
    walkR,
    hook,
    down
}
public enum PlayerKeyCommand
{
    none,
    roll,
    jump
}
public enum PlayerKeyUpDownCommand
{
    none,
    draw
}
public enum PlayerMeleeCommand
{
    none,
    melee1,
    melee2
}

public enum PlayerCommand
{
    idle,
    walk,
    roll,
    jump,
    hook,
    down
}

public enum Attack
{
    idle,
    bow,
    melee
}

public enum PlayerLife
{
    live,
    die
}

public class PlayerManage
{
    private int health;
    private int arrow;
    private float speed;
    private float jump;

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

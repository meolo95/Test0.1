using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerCommand
{
    idle,
    walk,
    roll,
    jump,
    hook
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

    public PlayerManage(int health, int arrow)
    {
        this.health = health;
        this.arrow = arrow;
    }

}

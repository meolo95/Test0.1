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
public class PlayerManage : MonoBehaviour
{
    public static PlayerManage Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        SetInfo(15, 30);
        
    }

    [SerializeField] GameObject player;

    private int _hp;
    private int _arrow;
    private int _dir = 1;

    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
        }
    }
    public int arrow
    {
        get
        {
            return _arrow;
        }
        set
        {
            _arrow = value;
        }
    }
    public int dir
    {
        get
        {
            return _dir;
        }
        set
        {
            _dir = value;
        }
    }

    void SetInfo(int h, int a)
    {
        hp = h;
        arrow = a;
    }

    public Vector3 PlayerPosition()
    {
        return player.transform.position;
    }

}

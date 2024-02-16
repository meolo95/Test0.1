using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
public interface IPDie
{
    void Die();
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
    devine,

}


public enum PlayerLife
{
    live,
    die
}

public static class PState 
{ 
    public static Dictionary<PlayerState, bool> states = new Dictionary<PlayerState, bool>();
}
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
        SetInfo(15, 30, 0);

        anim = player.GetComponent<Animator>();
        hook = player.GetComponent<PlayerHook>();
        SceneManager.sceneLoaded += OnStart;
    }

    [SerializeField] GameObject player;
    Animator anim;
    PlayerHook hook;
    [SerializeField] HeartClass heart;
    [SerializeField] HeartClass fheart;
    [SerializeField] GameObject PlayerUI;


    

    private int stagehp;

    private int _hp;
    private int _arrow;
    private int _dir = 1;
    private int _fhp;

    public int kills = 0;
    public int hits = 0;
    public float timer = 0f;
    public int min = 0;

    public bool isPlay;


    public int frozenHp
    {
        get
        {
            return _fhp;
        }
        set
        {
            _fhp = value;
            fheart.UpdateHearts();
            if (_fhp >= _hp)
            {
                PlayerCommand.plife = PlayerLife.die;
                KeyManager.Instance.optionManager.SetOverPanel();
            }
        }
    }
    public int hp
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            heart.UpdateHearts();
            if (_hp <= 0)
            {
                PlayerCommand.plife = PlayerLife.die;
                //KeyManager.Instance.optionManager.isMain = true;
                KeyManager.Instance.optionManager.SetOverPanel();
            }
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

    void OnStart(Scene scene, LoadSceneMode mode)
    {
        player.transform.position = new Vector3(-14.7f, -6.7f, 0f);
    }

    void SetInfo(int h, int a, int fhp)
    {
        hp = h;
        arrow = a;
        frozenHp = fhp;
    }

    public Vector3 PlayerPosition()
    {
        return player.transform.position;
    }

    public void PlayerReset()
    {
        PlayerCommand.plife = PlayerLife.live;
        SetInfo(stagehp, 30, 0);
        anim.SetBool("IsDie", false);
        anim.SetBool("IsIdle", true);
    }

    public void AllNewRefresh(int Lv)
    {
        switch(Lv)
        {
            case 1:
                hp = 24;
                break;
            case 2:
                hp = 20;
                break;
            case 3:
                hp = 16;
                break;
            case 4:
                hp = 12;
                break;
            case 5:
                hp = 8;
                break;
        }
        stagehp = hp;


    }

    public void UIActive()
    {
        PlayerUI.SetActive(true);
    }
    public void UIDActive()
    {
        PlayerUI.SetActive(false);
    }

}

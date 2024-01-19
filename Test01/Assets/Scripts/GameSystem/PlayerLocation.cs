using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocation : MonoBehaviour
{

    public static PlayerLocation Instance = null;

    [SerializeField] Player player;
    [SerializeField] Walking walking;
    [SerializeField] PlayerHit hit;
    [SerializeField] BowAttack bowAttack;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] AnimationManager animationManager;
    [SerializeField] HeartManager heartManager;
    [SerializeField] HeartManager blueHeart;

    public GameObject p;
    public GameObject pManager;

    public int kills = 0;
    public int hits = 0;
    public float timer = 0f;
    public int min = 0;

    public bool doingSomething = false;
    public bool hooking;

    public bool bowing;
    public int normalH;
    public bool isPlay;
    public bool isEnding;

    public int dir;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this )
            {
                Destroy(gameObject);
                return;
            }
        }

    }

    private void Update()
    {
        if (isPlay)
        {
            timer += Time.deltaTime;
            if (timer >= 60f)
            {
                min++;
                timer = 0f;
            }
        }
    }

    public void SetNormal()
    {
        walking.anim.SetBool("IsDie", false);
        walking.anim.SetBool("IsAttack", false);
        walking.anim.SetBool("IsAttackArrow", false);
        walking.anim.SetBool("IsIdle", true);
    }

    public void SetPlayerNormal()
    {
        hit.health = normalH;
        player.arrowNum = 30;
        player.rigid.velocity = Vector3.zero;
        player.transform.position = new Vector3(-14.7f, -6.7f, 0f);
        player.isAlive = true;
        player.ishit = false;
        player.isDevine = false;
        player.isAttack = false;
        player.isJumping = false;
        player.isRoll = false;
        walking.isCool = false;
        walking.anim.SetBool("IsDie", false);
        PlayerLine.Instance.TurnOff();
        hit.SetNColor();
        heartManager.UpdateHearts();
        SetHeat();
        kills = 0;
        hits = 0;
        timer = 0f;
        min = 0;
        PoolManager.Instance.Init();

    }

    public void SetMain()
    {
        player.transform.position = new Vector3(-5f, 0f, 0f);
    }

    public void SetPLv(int num)
    {
        if (num == 1)
        {
            normalH = 24;
        }
        if (num == 2)
        {
            normalH = 20;
        }
        if (num == 3)
        {
            normalH = 16;
        }
        if (num == 4)
        {
            normalH = 12;
        }
        if (num == 5)
        {
            normalH = 8;
        }
    }


    public int PlayerHp()
    {
        return hit.health;
    }

    public int FrozenHp()
    {
        return hit.frozenHp;
    }


    public void HitPlayer()
    {
        hit.DemagePlayer(1);
    }

    public void FreezePlayer()
    {
        hit.frozenHp += 1;
        blueHeart.FrozenHearts();
        hit.FreezePlayer();
    }

    public void SetHeat()
    {
        hit.frozenHp = 0;
        blueHeart.FrozenHearts();
    }

    public void PlayerHitAction()
    {
        hits++;
        heartManager.UpdateHearts();
    }

    public Vector3 PlayerPosition()
    {
        Vector3 pos = player.transform.position;
        return pos;
    }

    public float BowAngle()
    {
        float angle = bowAttack.angle;
        if (angle > 1f)
        {
            angle = 0.99f;
        }
        return angle;
    }

    public Vector2 BowLockOn()
    {
        Vector2 angle = bowAttack.LockOn();
        return angle;
    }

    public void GetDirection(bool isRight)
    {
        if (isRight)
        {

            player.transform.localScale = Vector3.right;
        }
        if (isRight == false)
        {

            player.transform.localScale = Vector3.left;
        }
    }

    public float hodir()
    {
        float dir = player.hordir;
        
        return dir;
    }

    public void SetDirection(bool isRight)
    {
        if (isRight)
        {
            player.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (isRight == false)
        {
            player.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
    }


    public void DefaultAngle()
    {
        bowAttack.angle = -0.5f;
    }

    public int GetArrowNum()
    {
        int num = player.arrowNum;

        return num;
    }

    public void UseArrow(int arrow)
    {
        player.arrowNum += arrow;
        if (player.arrowNum == 0)
        {
            animationManager.ArrowZero();
        }
        if (player.arrowNum > 0)
        {
            animationManager.ArrowFull();
        }
    }

    public int Arrows()
    {
        return player.arrowNum;
    }

    public void SetWeapon(int weaponNum, float delay, float attackTime)
    {
        playerAttack.weaponNum = weaponNum;
        playerAttack.SetAttackZone(weaponNum);
        playerAttack.delay = delay;
        playerAttack.timeToAttack = attackTime;
    }

    public int GetWeaponNum()
    {
        return playerAttack.weaponNum;
    }    

    public void SetAnimation()
    {
        animationManager.GoToHand();
    }

    public void GetSpear()
    {
        animationManager.GoToSpear();
        Debug.Log("GetSpear");
    }


    public bool PlayerJump()
    {
        if (player.rigid.velocity.y > 0.2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

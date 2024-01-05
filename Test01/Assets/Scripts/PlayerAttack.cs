using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    private GameObject attackZone = default;
    private GameObject attackZone2 = default;
    private bool attacking = false;
    //[SerializeField] public float timeToAttack;
    private float timer = 0f;
    //[SerializeField] public float delay;
    public float timeToAttack;
    public float delay;
    public float timeToAttack2;
    public float delay2;
    Walking walking;
    Player player;
    bool waitforattack = true;
    private float attacktimer = 0f;
    public int weaponNum;
    bool AttackType1;
    bool AttackType2;

    //[SerializeField] float weaponHp;
    // Start is called before the first frame update
    void Start()
    {
        walking = GetComponent<Walking>();
        player = GetComponent<Player>();
        //attackZone = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (KeyManager.Instance.isMouse)
        {
            if (waitforattack)
            {
                attacktimer += Time.deltaTime;
                if (attacktimer > delay + 0.15)
                {
                    if (PlayerLocation.Instance.doingSomething == false)
                    {
                        if (Input.GetMouseButton(1))
                        {
                            AttackType1 = true;
                            attacktimer = 0f;
                            if (attacking == false)
                            {
                                walking.anim.SetBool("IsAttack", true);
                                player.isAttack = true;
                            }
                            Invoke("Attack", delay);
                        }
                        if (Input.GetMouseButton(2) && PlayerLocation.Instance.GetArrowNum() > 0)
                        {
                            AttackType2 = true;
                            attacktimer = 0f;
                            if (attacking == false)
                            {
                                walking.anim.SetBool("IsAttackArrow", true);
                                player.isAttack = true;
                            }
                            Invoke("Attack2", delay2);
                        }
                    }
                }
            }

            if (attacking)
            {

                timer += Time.deltaTime;


                if (AttackType1)
                {
                    if (timer > timeToAttack)
                    {
                        timer = 0f;
                        attacking = false;
                        attackZone.SetActive(attacking);
                        attackZone2.SetActive(attacking);

                        player.isAttack = false;
                        walking.anim.SetBool("IsAttack", false);
                        walking.anim.SetBool("IsAttackArrow", false);
                        waitforattack = true;

                        AttackType1 = false;
                    }
                }

                if (AttackType2)
                {
                    if (timer > timeToAttack2)
                    {
                        timer = 0f;
                        attacking = false;
                        attackZone.SetActive(attacking);
                        attackZone2.SetActive(attacking);

                        player.isAttack = false;
                        walking.anim.SetBool("IsAttack", false);
                        walking.anim.SetBool("IsAttackArrow", false);
                        waitforattack = true;

                        AttackType2 = false;
                    }
                }

            }
        }
        
        if (KeyManager.Instance.isKey)
        {
            if (waitforattack)
            {
                attacktimer += Time.deltaTime;
                if (attacktimer > delay + 0.15)
                {
                    if (PlayerLocation.Instance.doingSomething == false)
                    {
                        if (Input.GetKey(KeySetting.keys[KeyAction.Attack1]))
                        {
                            AttackType1 = true;
                            attacktimer = 0f;
                            if (attacking == false)
                            {
                                walking.anim.SetBool("IsAttack", true);
                                player.isAttack = true;
                            }
                            Invoke("Attack", delay);
                        }
                        if (Input.GetKey(KeySetting.keys[KeyAction.Attack2]) && PlayerLocation.Instance.GetArrowNum() > 0)
                        {
                            AttackType2 = true;
                            attacktimer = 0f;
                            if (attacking == false)
                            {
                                walking.anim.SetBool("IsAttackArrow", true);
                                player.isAttack = true;
                            }
                            Invoke("Attack2", delay2);
                        }
                    }
                }
            }

            if (attacking)
            {

                timer += Time.deltaTime;


                if (AttackType1)
                {
                    if (timer > timeToAttack)
                    {
                        timer = 0f;
                        attacking = false;
                        attackZone.SetActive(attacking);
                        attackZone2.SetActive(attacking);

                        player.isAttack = false;
                        walking.anim.SetBool("IsAttack", false);
                        walking.anim.SetBool("IsAttackArrow", false);
                        waitforattack = true;

                        AttackType1 = false;
                    }
                }

                if (AttackType2)
                {
                    if (timer > timeToAttack2)
                    {
                        timer = 0f;
                        attacking = false;
                        attackZone.SetActive(attacking);
                        attackZone2.SetActive(attacking);

                        player.isAttack = false;
                        walking.anim.SetBool("IsAttack", false);
                        walking.anim.SetBool("IsAttackArrow", false);
                        waitforattack = true;

                        AttackType2 = false;
                    }
                }

            }
        }
        


    }

    void FixedUpdate()
    {
        
    }

    public void SetAttackZone(int weaponNum)
    {
        attackZone = transform.GetChild(weaponNum).gameObject;
        attackZone2 = transform.GetChild(weaponNum+1).gameObject;
    }


    private void Attack()
    {
        waitforattack = false;
        attacking = true;
        attackZone.SetActive(attacking);
        attackZone.GetComponent<AttackZone>().isUsed = false;
    }
    private void Attack2()
    {
        waitforattack = false;
        attacking = true;
        attackZone2.SetActive(attacking);
        attackZone2.GetComponent<AttackZone>().isUsed = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (Input.GetKey(KeyCode.Q))
    //    {
    //        if (collision.gameObject.tag == "HitZone")
    //        {

    //            Debug.Log("EnemyHit!");
    //            enemy.GetComponent<Enemy>().HitByPlayer();
    //        }
    //    }

    //    if (collision.gameObject.tag == "HitZone")
    //    {

    //        Debug.Log("EnemyHit!");
    //        enemy.GetComponent<Enemy>().HitByPlayer();
    //    }
    //}


}

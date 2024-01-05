using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Walking : MonoBehaviour
{
    public Rigidbody2D rigid;
    [SerializeField] float speed;
    [SerializeField] float jumpspeed;
    [SerializeField] float rollSpeed;
    public Animator anim;
    Player player;

    [SerializeField] GameObject physicsZone;

    BoxCollider2D physicsCollider;

    [SerializeField] float downSize;

    Vector2 physicsSize;

    public bool isIce;

    public bool isCool;

    bool isDown;

    bool isMoving;

    public AudioSource audioSource;

    public AudioClip[] clips;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsWalking", false);
        //anim.SetBool("IsJumping", false);
        physicsCollider = physicsZone.GetComponent<BoxCollider2D>();
        physicsSize = physicsCollider.size;
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("IsJumping", true);


        if (anim.GetBool("IsWalking") && anim.GetBool("IsJumping") != true)
        {
            audioSource.clip = clips[0];
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }

        if (Input.GetKeyDown(KeySetting.keys[KeyAction.Jump]) && player.isAttack == false)
        {
            if (player.isAlive == true && PlayerLocation.Instance.hooking == false)
            {
                if (anim.GetBool("IsJumping") != true && player.ishit != true)
                {
                    if (isDown == false)
                    {
                        //audioSource.clip = clips[1];
                        //audioSource.Play();
                        player.isJumping = true;
                        anim.SetBool("IsJumping", true);
                        rigid.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
                    }
                    
                }
            }
        }

        if (PlayerLocation.Instance.doingSomething == false && PlayerLocation.Instance.hooking == false)
        {
            if (Input.GetKey(KeySetting.keys[KeyAction.Roll]) && player.isAttack == false)
            {
                if (player.isAlive == true && isCool == false)
                {
                    if (anim.GetBool("IsRolling") != true && player.ishit != true)
                    {
                        isCool = true;
                        rigid.velocity = Vector2.zero;
                        PlayerLocation.Instance.doingSomething = true;
                        anim.SetBool("IsRolling", true);
                        anim.SetBool("IsWalking", false);
                        rigid.AddForce(new Vector2(player.hordir * rollSpeed, 0f), ForceMode2D.Impulse);
                        audioSource.clip = clips[2];
                        audioSource.Play();
                        StartCoroutine(WaitRoll());
                    }
                }
            }
        }



    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(0.5f);
        isCool = false;
    }

    IEnumerator WaitRoll()
    {
        player.isRoll = true;
        yield return new WaitForSeconds(0.5f);
        player.isDevine = false;
        player.isRoll = false;
        anim.SetBool("IsRolling", false);
        PlayerLocation.Instance.doingSomething = false;
        StartCoroutine(CoolTime());
    }

    private void FixedUpdate()
    {
        if (player.ishit != true && player.isAlive == true)
        {
            float dir = Input.GetAxisRaw("Horizontal");
            float down = Input.GetAxisRaw("Vertical");


            if (PlayerLocation.Instance.doingSomething == true)
            {
                anim.SetBool("IsDown", false);
                physicsCollider.size = physicsSize;
            }

            if (player.isRoll == false && PlayerLocation.Instance.hooking == false)
            {

                if (Input.GetKey(KeySetting.keys[KeyAction.Right]) && player.isAttack == false)
                {
                    if (isDown == false)
                    {
                        if (PlayerLocation.Instance.bowing == false)
                        {
                            transform.localScale = new Vector3(1, 1, 1);
                        }
                        transform.localScale = new Vector3(1, 1, 1);
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("IsIdle", false);
                        rigid.velocity = new Vector2(1 * speed, rigid.velocity.y);
                        dir = 1;
                    }
                }
                else if (Input.GetKey(KeySetting.keys[KeyAction.Left]) && player.isAttack == false)
                {
                    if (isDown == false)
                    {
                        if (PlayerLocation.Instance.bowing == false)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                        }
                        anim.SetBool("IsWalking", true);
                        anim.SetBool("IsIdle", false);
                        rigid.velocity = new Vector2(-1 * speed, rigid.velocity.y);
                        dir = -1;
                    }
                }
                else
                {
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsIdle", true);
                    //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
                }
                
                if (Input.GetKey(KeySetting.keys[KeyAction.Down]) && PlayerLocation.Instance.doingSomething == false)
                {
                    if (player.isAttack == false && PlayerLocation.Instance.hooking == false)
                    {
                        anim.SetBool("IsDown", true);
                        Vector2 newSize = physicsCollider.size;
                        newSize.y = downSize;
                        physicsCollider.size = newSize;
                        isDown = true;

                    }
                }
                else
                {
                    anim.SetBool("IsDown", false);
                    physicsCollider.size = physicsSize;
                    isDown = false;
                }
            }

        }

    }


    void JumpAnima()
    {
        Vector3 raypos1 = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
        Vector3 raypos2 = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
        RaycastHit2D rayHit1 = Physics2D.Raycast(raypos1, Vector3.down, 1f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(raypos2, Vector3.down, 1f, LayerMask.GetMask("Platform"));

        if (rayHit1.collider != null || rayHit2.collider != null)
        {
            anim.SetBool("IsJumping", false);

            if (rayHit1.distance < 0.66f || rayHit2.distance < 0.66f)
            {
                //anim.SetBool("IsJumping", false);
            }
        }
    }

    void JumpAnima2()
    {
        Vector3 raypos1 = new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
        Vector3 raypos2 = new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
        if (rigid.velocity.y < 0)
        {
            RaycastHit2D rayHit1 = Physics2D.Raycast(raypos1, Vector3.down, 1f, LayerMask.GetMask("Platform"));
            RaycastHit2D rayHit2 = Physics2D.Raycast(raypos2, Vector3.down, 1f, LayerMask.GetMask("Platform"));

            if (rayHit1.collider != null || rayHit2.collider != null)
            {
                anim.SetBool("IsJumping", false);

                if (rayHit1.distance < 0.66f || rayHit2.distance < 0.66f)
                {
                    //anim.SetBool("IsJumping", false);
                }
            }
        }
    }


}

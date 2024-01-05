using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;




public class Enemy : MonoBehaviour
{
    public enum State { ArrowHit, Melee1, Melee2, Shielding, Small }
    
    SpriteRenderer spriteRenderer;
    public Rigidbody2D rigid;
    [SerializeField] float stun;

    [SerializeField] bool isAnim;
    //public Transform target;
    Animator enemyAnim;

    public bool isHit;
    
    public bool isAlive = true;

    public GameObject HitZone = default;

    public bool hited;
    [SerializeField] public int health;
    [SerializeField] public bool Shielding = false;

    public int demage;

    //[SerializeField] public float stun;
    // Start is called before the first frame update
    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //rigid = GetComponent<Rigidbody2D>();

        //target= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        enemyAnim = GetComponent<Animator>();

        HitZone = transform.GetChild(0).gameObject;

        rigid.velocity = Vector3.zero;

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()
    {
        if (hited)
        {
            SoundManager.Instance.SFXHitPlay("Hit", transform.position, 0.5f, 10f);
            HitByPlayer();
            health -= demage;
            if (health <= 0)
            {
                DestroyEnemy();
            }

            hited = false;
        }

        
    }
    

    public void HitByPlayer()
    {
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition();
        rigid.velocity = Vector3.zero;
        if (playerPos.x < transform.position.x)
        {
            rigid.AddForce(new Vector2(1, 1) * stun, ForceMode2D.Impulse);
        }
        else if (playerPos.x >= transform.position.x)
        {
            rigid.AddForce(new Vector2(-1, 1) * stun, ForceMode2D.Impulse);
        }
        isHit = true;
    }

    public void DestroyEnemy()
    {
        PlayerLocation.Instance.kills++;
        if (isAnim == false)
        {
            enemyAnim.SetBool("IsDie", true);
        }
        if (isAnim)
        {
            Blur();
        }
        HitZone.SetActive(false);
        isAlive = false;
        Destroy(gameObject, 2f);
        rigid.gravityScale = 3f;
    }

    void Blur()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
    }





}

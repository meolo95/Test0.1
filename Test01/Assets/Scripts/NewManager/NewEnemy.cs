using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator enemyAnim;
    public GameObject HitZone = default;

    private float stun;
    private bool isAnim;
    private bool isAlive = true;
    // Start is called before the first frame update

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //isHit = true;
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

public class NewHealth : NewEnemy
{
    private int health;
    //GameObject obj;
    private int demage;
    //Enemy enemy;

    [SerializeField] public GameObject body;


    // get set private
    //


    private bool Shielding = false;
    [SerializeField] public bool isSmall;
    private void DemageEnemy(int amount)
    {
        if (Shielding == false)
        {
            SoundManager.Instance.SFXHitPlay("Hit", transform.position, 0.5f, 10f);
            HitByPlayer();
            health -= amount;
            if (health <= 0)
            {
                DestroyEnemy();
            }
        }

        if (Shielding)
        {
            SoundManager.Instance.SFXHitPlay("Blocked", transform.position, 1f, 15f);
        }
    }
}

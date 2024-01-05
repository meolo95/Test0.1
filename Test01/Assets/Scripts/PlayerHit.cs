using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    [SerializeField] Player player;
    Walking walking;

    [SerializeField] public int Armor;

    [SerializeField] GameObject[] parts;
    public SpriteRenderer[] spriteRenderer;

    [SerializeField] public int health;

    public int frozenHp;

    // Start is called before the first frame update
    void Start()
    {
        walking = GetComponent<Walking>();
        

        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i] = parts[i].GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayerDevine()
    {
        player.isDevine = true;
        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i].color = new Color(1f, 1f, 1f, 0.6f);
        }
        yield return new WaitForSeconds(player.devineTime);
        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i].color = new Color(1f, 1f, 1f, 1f);
        }
        player.isDevine = false;
    }

    public void SetNColor()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            spriteRenderer[i].color = new Color(1f, 1f, 1f, 1f);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //player.ishit = false;
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //player.ishit = false;
        }

    }

    IEnumerator Hit;

    private void HitCoStart()
    {
        Hit = HitWait();
        StartCoroutine(Hit);
    }

    private void HitCoStop()
    {
        Hit = HitWait();
        StopCoroutine(Hit);
    }

    IEnumerator HitWait()
    {
        yield return new WaitForSeconds(0.2f);
        player.ishit = false;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player.isDevine == false && player.isRoll == false)
        {
            if (other.gameObject.tag == "HitZone")
            {
                StartCoroutine(PlayerDevine());
                player.ishit = true;
                player.rigid.velocity = Vector3.zero;

                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(1, 1) * player.stun, ForceMode2D.Impulse);
                }
                else if (other.gameObject.transform.position.x >= transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(-1, 1) * player.stun, ForceMode2D.Impulse);
                }
                HitCoStart();
                Health health = other.gameObject.GetComponent<Health>();

                DemagePlayer(health.demage);
            }

            if (other.gameObject.tag == "Projectile")
            {
                StartCoroutine(PlayerDevine());
                player.ishit = true;
                player.rigid.velocity = Vector3.zero;

                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(1, 1) * player.stun, ForceMode2D.Impulse);
                }
                else if (other.gameObject.transform.position.x >= transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(-1, 1) * player.stun, ForceMode2D.Impulse);
                }
                HitCoStart();
                PublicProjectile pubPro = other.gameObject.GetComponent<PublicProjectile>();

                DemagePlayer(pubPro.demage); ;

            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (player.isDevine == false && player.isRoll == false)
        {
            if (other.gameObject.tag == "HitZone")
            {
                StartCoroutine(PlayerDevine());
                player.ishit = true;
                player.rigid.velocity = Vector3.zero;

                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(1, 1) * player.stun, ForceMode2D.Impulse);
                }
                else if (other.gameObject.transform.position.x >= transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(-1, 1) * player.stun, ForceMode2D.Impulse);
                }
                HitCoStart();
                Health health = other.gameObject.GetComponent<Health>();

                DemagePlayer(health.demage);

            }

            if (other.gameObject.tag == "Projectile")
            {
                StartCoroutine(PlayerDevine());
                player.ishit = true;
                player.rigid.velocity = Vector3.zero;

                if (other.gameObject.transform.position.x < transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(1, 1) * player.stun, ForceMode2D.Impulse);
                }
                else if (other.gameObject.transform.position.x >= transform.position.x)
                {
                    player.rigid.AddForce(new Vector2(-1, 1) * player.stun, ForceMode2D.Impulse);
                }
                HitCoStart();
                PublicProjectile pubPro = other.gameObject.GetComponent<PublicProjectile>();

                DemagePlayer(pubPro.demage);
            }
        }
    }

    public void DemagePlayer(int demage)
    {
        if (player.isAlive)
        {
            health = health - demage;
            PlayerLocation.Instance.PlayerHitAction();

            if (health <= 0 || health - frozenHp <= 0)
            {
                health = 0;
                player.DestroyPlayer();
                
            }
        }
    }

    public void FreezePlayer()
    {
        if (health - frozenHp <= 0)
        {
            health = 0;
            player.DestroyPlayer();

        }
    }

    
}

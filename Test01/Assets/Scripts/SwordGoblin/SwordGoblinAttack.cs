using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGoblinAttack : MonoBehaviour
{
    SwordGoblin swordGoblin;
    [SerializeField] float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        swordGoblin = GetComponent<SwordGoblin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attacker;

    public void StartAttack(float pos)
    {
        if (swordGoblin.enemy.isAlive == true)
        {
            Attacker = Attack(pos);
            StartCoroutine(Attacker);
        }
    }
    public void StopAttack(float pos)
    {
        Attacker = Attack(pos);
        StopCoroutine(Attacker);
    }

    IEnumerator Attack(float position)
    {
        swordGoblin.DownShield();
        swordGoblin.rigid.velocity = Vector3.zero;

        swordGoblin.anim.SetBool("IsAttack", true);
        if (position > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            swordGoblin.rigid.AddForce(Vector2.right * attackSpeed, ForceMode2D.Impulse);
        }
        else if (position < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            swordGoblin.rigid.AddForce(Vector2.left * attackSpeed, ForceMode2D.Impulse);
        }

        StartCoroutine(CoolDown());
        yield return null;
    }

    IEnumerator CoolDown() 
    {
        yield return new WaitForSeconds(0.5f);
        swordGoblin.rigid.velocity = Vector3.zero;
        swordGoblin.anim.SetBool("IsAttack", false);

        yield return new WaitForSeconds(1f);
        
        swordGoblin.isTarget = false;
    }
}

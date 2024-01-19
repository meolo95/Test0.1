using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour, IAttack
{
    Rigidbody2D rigid;
    Animator anim;

    [SerializeField] float speed;
    [SerializeField] float delay;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (IEMelee == null)
        {
            MeleeStart();
        }
    }

    IEnumerator IEMelee;
    void MeleeStart()
    {
        IEMelee = Melee();
        StartCoroutine(IEMelee);
    }
    void MeleeStop()
    {
        StopCoroutine(IEMelee);
        IEMelee = null;
    }

    IEnumerator Melee()
    {
        anim.SetBool("IsAttack", true);
        rigid.velocity = Vector3.zero;
        if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
        {
            rigid.AddForce(new Vector2(1f * speed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x)
        {
            rigid.AddForce(new Vector2(-1f * speed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(-1f, 1f);
        }
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttack", false);
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(delay - 0.5f);
        IEMelee = null;
    }

}

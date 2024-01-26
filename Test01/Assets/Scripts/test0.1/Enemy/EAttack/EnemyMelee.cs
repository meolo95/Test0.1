using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyManage, IAttack
{
    [SerializeField] float speed;
    [SerializeField] float delay;
    [SerializeField] float time;

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
        AnimSetTrue("IsAttack");
        rigid.velocity = Vector3.zero;
        if (transform.position.x < PlayerManage.Instance.PlayerPosition().x)
        {
            rigid.AddForce(new Vector2(1f * speed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerManage.Instance.PlayerPosition().x)
        {
            rigid.AddForce(new Vector2(-1f * speed, 0f), ForceMode2D.Impulse);
            transform.localScale = new Vector2(-1f, 1f);
        }
        yield return new WaitForSeconds(time);
        AnimSetFalse("IsAttack");
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(delay);
        IEMelee = null;
    }

}

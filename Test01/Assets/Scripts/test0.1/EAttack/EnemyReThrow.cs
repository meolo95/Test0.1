using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReThrow : MonoBehaviour, IAttack
{
    Rigidbody2D rigid;
    Animator anim;
    [SerializeField] GameObject spike;

    int isAttack;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAttack = Animator.StringToHash("IsAttack");
    }
    public void Attack()
    {
        StartReThrow();
    }

    IEnumerator IEReThrow;

    void StartReThrow()
    {
        if (IEReThrow == null)
        {
            IEReThrow = EReThrow();
            StartCoroutine(IEReThrow);
        }
    }

    IEnumerator EReThrow()
    {
        anim.SetBool(isAttack, true);
        yield return new WaitForSeconds(1f);
        Instantiate(spike, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(spike, transform.position + Vector3.down, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(spike, transform.position + Vector3.down * 2f, Quaternion.identity);
        anim.SetBool(isAttack, false);
        yield return new WaitForSeconds(2f);
        IEReThrow = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReThrow : EnemyManage, IAttack
{
    [SerializeField] GameObject spike;
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
        AnimSetTrue("IsAttack");
        yield return new WaitForSeconds(1f);
        Instantiate(spike, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(spike, transform.position + Vector3.down, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(spike, transform.position + Vector3.down * 2f, Quaternion.identity);
        AnimSetFalse("IsAttack");
        yield return new WaitForSeconds(2f);
        IEReThrow = null;
    }
}

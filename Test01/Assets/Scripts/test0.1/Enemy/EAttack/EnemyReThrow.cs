using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReThrow : EnemyManage, IAttack
{
    [SerializeField] GameObject spike;
    [SerializeField] string objName;
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
        ObjectPoolManager.Instance.Get(objName, transform.position, Quaternion.identity, 0);
        yield return new WaitForSeconds(0.1f);
        ObjectPoolManager.Instance.Get(objName, transform.position + Vector3.down, Quaternion.identity, 0);
        yield return new WaitForSeconds(0.1f);
        ObjectPoolManager.Instance.Get(objName, transform.position + Vector3.down * 2, Quaternion.identity, 0);
        AnimSetFalse("IsAttack");
        yield return new WaitForSeconds(2f);
        IEReThrow = null;
    }
}

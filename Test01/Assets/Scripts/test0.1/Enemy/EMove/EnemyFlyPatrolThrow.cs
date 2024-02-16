using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyPatrolThrow : EnemyFlyPatrol, IEtc
{
    [SerializeField] GameObject knife;
    [SerializeField] string objName;
    public void Etc()
    {
        Move();
        StartThrow();
    }

    IEnumerator IEThrow;

    void StartThrow()
    {
        if(IEThrow == null)
        {
            IEThrow = Throw();
            StartCoroutine(IEThrow);
        }
    }

    IEnumerator Throw()
    {
        AnimSetTrue("IsAttack");
        yield return new WaitForSeconds(1.5f);
        ObjectPoolManager.Instance.Get(objName, transform.position, Quaternion.Euler(0f, 0f, -140f), 0);
        yield return new WaitForSeconds(0.5f);
        AnimSetFalse("IsAttack");
        yield return new WaitForSeconds(0.5f);
        IEThrow = null;
    }
}

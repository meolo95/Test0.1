using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyManage, IDie
{
    public void Die()
    {
        if (IEDie == null)
        {
            DieStart();
        }
    }

    IEnumerator IEDie;
    void DieStart()
    {
        IEDie = WaitDie();
        StartCoroutine(IEDie);
    }
    void DieStop()
    {
        StopCoroutine(IEDie);
        IEDie = null;
    }

    IEnumerator WaitDie()
    {
        PlayerLocation.Instance.kills++;
        AnimSetTrue("IsDie");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}

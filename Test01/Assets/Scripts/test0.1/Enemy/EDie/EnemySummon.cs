using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySummon : ArrowReset, IDie
{
    [SerializeField] GameObject monster;
    
    public void Die(List<int> children)
    {
        if (IESummon == null)
        {
            lists = children;
            SummonStart();
        }
    }

    IEnumerator IESummon;
    void SummonStart()
    {
        IESummon = WaitSummon();
        StartCoroutine(IESummon);
    }
    void DieStop()
    {
        StopCoroutine(IESummon);
        IESummon = null;
    }

    IEnumerator WaitSummon()
    {
        PlayerLocation.Instance.kills++;
        AnimSetTrue("IsDie");
        Instantiate(monster, transform.position, Quaternion.identity);
        Ref(lists);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}

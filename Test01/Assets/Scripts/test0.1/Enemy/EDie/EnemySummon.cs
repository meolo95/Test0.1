using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour, IDie
{
    [SerializeField] GameObject monster;
    public void Die()
    {
        if (IESummon == null)
        {
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
        yield return new WaitForSeconds(3f);
        Instantiate(monster, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

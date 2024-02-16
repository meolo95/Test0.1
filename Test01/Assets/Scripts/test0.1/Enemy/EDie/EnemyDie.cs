using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class EnemyDie : ArrowReset, IDie
{
    public void Die(List<int> children)
    {
        if (IEDie == null)
        {
            lists = children;
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
        transform.GetChild(0).gameObject.SetActive(false);
        PlayerManage.Instance.kills++;
        AnimSetTrue("IsDie");
        yield return new WaitForSeconds(3f);
        Ref(lists);
        gameObject.SetActive(false);
    }

    
    
}

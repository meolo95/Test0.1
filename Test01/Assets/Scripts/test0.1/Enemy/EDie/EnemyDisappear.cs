using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisappear : ArrowReset, IDie
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
        PlayerLocation.Instance.kills++;
        AnimSetTrue("IsDie");
        Ref(lists);
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}

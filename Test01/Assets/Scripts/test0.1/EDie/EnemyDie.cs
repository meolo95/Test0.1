using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour, IDie
{
    Animator anim;
    int die;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        die = Animator.StringToHash("IsDie");
    }
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
        anim.SetBool(die, true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}

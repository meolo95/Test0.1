using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee2 : PlayerBehaviour, IMelee2
{
    [SerializeField] GameObject attackZone;
    [SerializeField] float delay;
    [SerializeField] float time;
    protected override void Awake()
    {
        base.Awake();
        //attackZone = transform.GetChild(1).gameObject;
    }
    public void Melee2()
    {
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.Attack2]))
        {
            StartMelee();
        }
    }


    IEnumerator IEMelee;

    void StartMelee()
    {
        if (IEMelee == null)
        {
            IEMelee = EMelee();
            StartCoroutine(IEMelee);
        }
    }

    IEnumerator EMelee()
    {
        anim.SetBool("IsAttackArrow", true);
        PState.states[PlayerState.melee] = true;
        yield return new WaitForSeconds(delay);
        attackZone.SetActive(true);
        yield return new WaitForSeconds(time);
        anim.SetBool("IsAttackArrow", false);
        attackZone.SetActive(false);
        PState.states[PlayerState.melee] = false;
        IEMelee = null;
    }
}

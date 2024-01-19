using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee1 : PlayerBehaviour, IMelee1
{
    GameObject attackZone;
    [SerializeField] float delay;
    [SerializeField] float time;
    protected override void Awake()
    {
        base.Awake();
        attackZone = transform.GetChild(2).gameObject;
    }
    public void Melee1()
    {
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.Attack1]))
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
        anim.SetBool("IsAttack", true);
        PState.states[PlayerState.melee] = true;
        yield return new WaitForSeconds(delay);
        attackZone.SetActive(true);
        yield return new WaitForSeconds(time);
        anim.SetBool("IsAttack", false);
        attackZone.SetActive(false);
        PState.states[PlayerState.melee] = false;
        IEMelee = null;
    }


}

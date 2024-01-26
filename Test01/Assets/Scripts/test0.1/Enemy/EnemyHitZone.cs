using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHitZone : MonoBehaviour
{
    EnemyBehavior behavior;

    private void Awake()
    {
        behavior = GetComponentInParent<EnemyBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (behavior.life == EnemyLife.living)
        {
            if (behavior.hitBehavior != null)
            {
                if (collision.TryGetComponent(out AttackZone attackZone))
                {
                    if (attackZone.isUsed == false)
                    {
                        attackZone.isUsed = true;
                        if (behavior.isDevine != true)
                        {
                            behavior.hitState = EnemyHitState.hitting;
                            behavior.check = false;
                            behavior.EnemyManage(-attackZone.demage);


                            delayStop();
                            delayStart();
                        }
                    }
                }
            }

        }
    }

    IEnumerator IEdelay;

    void delayStart()
    {
        IEdelay = delay();
        StartCoroutine(IEdelay);
    }
    
    void delayStop()
    {
        if (IEdelay != null)
        {
            StopCoroutine(IEdelay);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.5f);
        behavior.hitState = EnemyHitState.idle;

    }

}

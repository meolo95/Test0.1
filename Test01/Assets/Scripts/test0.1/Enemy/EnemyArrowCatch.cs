using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowCatch : MonoBehaviour
{
    EnemyBehavior behavior;
    [SerializeField] float delay;
    [SerializeField] float cool;

    private void Awake()
    {
        behavior = GetComponentInParent<EnemyBehavior>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IEdelay == null)
        {
            if (behavior.life == EnemyLife.living)
            {
                if (collision.TryGetComponent(out AttackZone attackZone))
                {
                    if (attackZone.isUsed == false)
                    {
                        behavior.state = EnemyState.Etc;
                        behavior.isDevine = true;
                        delayStart(delay);

                    }
                }

            }
        }
    }


    IEnumerator IEdelay;

    void delayStart(float delay)
    {
        IEdelay = Getdelay(delay);
        StartCoroutine(IEdelay);
    }

    void delayStop()
    {
        if (IEdelay != null)
        {
            StopCoroutine(IEdelay);
        }
    }

    IEnumerator Getdelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        behavior.isDevine = false;
        behavior.hitState = EnemyHitState.idle;
        behavior.state = EnemyState.moving;
        yield return new WaitForSeconds(cool);
        IEdelay = null;
    }
}

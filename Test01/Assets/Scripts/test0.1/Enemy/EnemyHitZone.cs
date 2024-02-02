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
                            if (attackZone.usedArrow != null)
                            {
                                GameObject sharedParent = new GameObject("Father");
                                sharedParent.transform.position = collision.gameObject.transform.position;
                                sharedParent.transform.rotation = collision.gameObject.transform.rotation;
                                sharedParent.transform.SetParent(gameObject.transform);
                                Vector3 hitpos = collision.transform.position;
                                hitpos += collision.transform.right * 0.2f;
                                GameObject newArrows = Instantiate(attackZone.usedArrow, hitpos, collision.transform.rotation);
                                newArrows.transform.SetParent(sharedParent.transform, true);
                                Destroy(collision.gameObject);
                            }


                            delayStop();
                            delayStart();
                        }
                        else
                        {
                            if (attackZone.usedArrow != null)
                            {
                                Vector3 hitpos = collision.transform.position;
                                hitpos += collision.transform.right * 0.2f;
                                GameObject newArrows = Instantiate(attackZone.blockedArrow, hitpos, collision.transform.rotation);
                                Destroy(collision.gameObject);

                            }
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

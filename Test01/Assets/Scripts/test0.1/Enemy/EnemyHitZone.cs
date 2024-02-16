using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHitZone : MonoBehaviour
{
    EnemyBehavior behavior;
    [SerializeField] Transform trans;

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
                            
                            if (attackZone.usedArrow != null)
                            {
                                Vector3 hitpos = collision.transform.position;
                                hitpos += collision.transform.right * 0.2f;
                                GameObject usedArrows = ObjectPoolManager.Instance.Get("UsedArrow", hitpos, collision.transform.rotation, 0);
                                usedArrows.transform.SetParent(trans, true);
                                usedArrows.GetComponent<UsedArrow>().isEnemy = true;
                                behavior.children.Add(usedArrows.GetComponent<Pooler>().key);
                                ObjectPoolManager.Instance.ReleaseOnPull("Arrow", attackZone.key);
                            }
                            behavior.hitState = EnemyHitState.hitting;
                            behavior.check = false;
                            behavior.EnemyManage(-attackZone.demage);

                            delayStop();
                            delayStart();
                        }
                        else
                        {
                            if (attackZone.usedArrow != null)
                            {
                                Vector3 hitpos = collision.transform.position;
                                hitpos += collision.transform.right * 0.2f;
                                GameObject newArrows = ObjectPoolManager.Instance.Get("BlockedArrow", hitpos, collision.transform.rotation, transform.position.x);
                                ObjectPoolManager.Instance.ReleaseOnPull("Arrow", attackZone.key);

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
        yield return new WaitForSeconds(1f);
        behavior.hitState = EnemyHitState.idle;

    }

}

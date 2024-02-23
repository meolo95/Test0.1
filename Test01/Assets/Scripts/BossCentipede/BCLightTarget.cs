using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public interface IFind
{
    bool Find();
}

public class BCLightTarget : MonoBehaviour , IFind
{
    [SerializeField] GameObject BC;

    public float viewRadius;
    [Range(0, 360)] public float viewAngle;

    public LayerMask targetMask, obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    bool check = true;

    public AudioClip clip;


    IEnumerator FindTarget(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    public bool Find()
    {
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        Collider2D[] platformViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, obstacleMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(-transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    StartWait();
                }
            }
        }

        if (visibleTargets.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    void FindVisibleTarget()
    {
        visibleTargets.Clear();
    }

    IEnumerator IEWait;

    void StartWait()
    {
        if (IEWait == null)
        {
            IEWait = Wait();
            StartCoroutine(IEWait);
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        FindVisibleTarget();
        IEWait = null;
    }
}

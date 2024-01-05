using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BCLightTarget : MonoBehaviour
{
    [SerializeField] GameObject BC;

    public float viewRadius;
    [Range(0, 360)] public float viewAngle;

    public LayerMask targetMask, obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    bool check = true;

    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindTarget(0.2f));
    }

    IEnumerator FindTarget(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        visibleTargets.Clear();

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
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (visibleTargets.Count > 0)
        {
            if (check)
            {
                StartCoroutine(Wait());
            }
        }

    }

    IEnumerator Wait()
    {
        check = false;
        BC.GetComponent<BCMove>().isTarget = true;
        BC.GetComponent<BCMove>().playerPos = PlayerLocation.Instance.PlayerPosition();
        BC.GetComponent<BCMove>().thisPos = BC.transform.position;
        BC.GetComponent<BCMove>().StartCo();
        SoundManager.Instance.SFXPlay("Growl", clip, 0.7f);
        yield return new WaitForSeconds(4f);
        BC.GetComponent<BCMove>().isTarget = false;
        check = true;
    }
}

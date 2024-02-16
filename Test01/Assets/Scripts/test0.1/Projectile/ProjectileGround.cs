using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGround : MonoBehaviour
{
    [SerializeField] GameObject usedProjectile;
    [SerializeField] string objName;
    [SerializeField] string usedObjName;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {

            Vector3 hitpos = transform.position;
            hitpos += transform.right * 0.2f;
            ObjectPoolManager.Instance.ReleaseOnPull(objName, gameObject.GetComponent<Pooler>().key);
            ObjectPoolManager.Instance.Get(usedObjName, hitpos, transform.rotation, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField] string objName;
    private void Awake()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            ObjectPoolManager.Instance.ReleaseOnPull(objName, gameObject.GetComponent<Pooler>().key);
        }
    }
}

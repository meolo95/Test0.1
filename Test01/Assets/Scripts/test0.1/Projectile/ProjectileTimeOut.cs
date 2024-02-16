using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTimeOut : MonoBehaviour
{
    [SerializeField] string objName;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        StartCoroutine(Wait());
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        ObjectPoolManager.Instance.ReleaseOnPull(objName, gameObject.GetComponent<Pooler>().key);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSpear : Pooler
{
    [SerializeField] string objName;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(7f);
        ObjectPoolManager.Instance.ReleaseOnPull(objName, key);
    }
}

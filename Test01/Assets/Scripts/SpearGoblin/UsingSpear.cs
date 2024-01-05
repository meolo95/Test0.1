using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSpear : MonoBehaviour
{
    Pooler pooler;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<Pooler>();
        Destroy(gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        pooler.ReleaseObject();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour
{
    public int key;
    public IObjectPool<GameObject> Pool {  get; set; }

    public void ReleaseObject()
    {
        Pool.Release(gameObject);
    }


}

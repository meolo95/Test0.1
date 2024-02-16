using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class PoolManager : MonoBehaviour
{

    [System.Serializable]
    private class ObjectInfo
    {
        public string objectName;
        public GameObject prefab;
        public int count;
    }

    public static PoolManager Instance;

    public bool isReady { get; private set; }

    
    [SerializeField] private ObjectInfo[] objectInfos = null;

    private string objectName;

    private Dictionary<string, IObjectPool<GameObject>> objectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    private Dictionary<string, GameObject> goDic = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Init();
    }

    public void Init()
    {
        isReady = false;

        for (int idx = 0; idx < objectInfos.Length; idx++)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
            OnDestroyPoolObject, true, objectInfos[idx].count, objectInfos[idx].count);

            if (goDic.ContainsKey(objectInfos[idx].objectName))
            {
                return;
            }
            goDic.Add(objectInfos[idx].objectName, objectInfos[idx].prefab);
            objectPoolDic.Add(objectInfos[idx].objectName, pool);

            for (int i = 0; i < objectInfos[idx].count; i++)
            {
                objectName = objectInfos[idx].objectName;
                Pooler pooler = CreatePooledItem().GetComponent<Pooler>();
                pooler.Pool.Release(pooler.gameObject);
                DontDestroyOnLoad(pooler.gameObject);
            }
        }

        isReady = true;
    }

    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(goDic[objectName]);
        poolGo.GetComponent<Pooler>().Pool = objectPoolDic[objectName];
        return poolGo;
    }
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    void SetNormal(GameObject poolGo, Vector3 pos, Quaternion rot)
    {
        poolGo.transform.position = pos;
        poolGo.transform.rotation = rot;
    }

    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }

    public GameObject GetGo(string goName)
    {
        objectName = goName;

        if (goDic.ContainsKey(goName) == false)
        {
            return null;
        }

        GameObject go = objectPoolDic[goName].Get();
        return objectPoolDic[goName].Get();
    }


    public GameObject ProjectileGo(string goName, Vector3 pos, Quaternion rot, float angle)
    {
        objectName = goName;

        if (goDic.ContainsKey(goName) == false)
        {
            return null;
        }

        GameObject go = objectPoolDic[goName].Get();
        go.transform.position = pos;
        go.transform.rotation = rot;
        go.GetComponent<AProjectile>().angle = angle;
        return go;
    }


    //public GameObject ArrowShow(string name, float angle, Vector)

}

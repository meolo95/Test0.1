using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class Objects
{
    public string objectName;
    public GameObject prefab;
    public int count;
}


public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance = null;
    [SerializeField] private Objects[] objects = null;

    Dictionary<string, Dictionary<int, GameObject>> objList = new Dictionary<string, Dictionary<int, GameObject>>();
    Dictionary<string, Dictionary<int, bool>> boolList = new Dictionary<string, Dictionary<int, bool>>();

    Dictionary<string, GameObject> objectList = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
    }

    void Init()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Dictionary<int, GameObject> PoolObject = new Dictionary<int, GameObject>();
            objList.Add(objects[i].objectName, PoolObject);
            Dictionary<int, bool> PoolOnBool = new Dictionary<int, bool>();
            boolList.Add(objects[i].objectName, PoolOnBool);
            for (int j = 0; j < objects[i].count; j++)
            {
                GameObject obj = Instantiate(objects[i].prefab);
                DontDestroyOnLoad(obj);
                objList[objects[i].objectName].Add(j, obj);
                boolList[objects[i].objectName].Add(j, false);

                //ReleaseOnPull(objects[i].objectName, j);
            }
        }
    }

    void Create(string objName)
    {
        int key = objList[objName].Count;
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].objectName == objName)
            {
                objList[objName].Add(key, objects[i].prefab);
                break;
            }
        }
    }

    void Destroy(string objName)
    {
        int key = objList[objName].Count;
        objList[objName].Remove(key);
    }


    public void ReleaseOnPull(string objName, int j)
    {
        GameObject obj = objList[objName][j];
        ParentKiller(obj);
        boolList[objName][j] = false;
        objList[objName][j].SetActive(false);
    }

    public GameObject Get(string objName, Vector3 pos, Quaternion rot, float angle)
    {
        for (int i = 0; i < boolList[objName].Count; i++)
        {
            if (boolList[objName][i] == false)
            {
                GameObject obj = objList[objName][i];
                Refresh(obj, pos, rot, angle);
                obj.SetActive(true);
                boolList[objName][i] = true;
                obj.GetComponent<Pooler>().key = i;
                return obj;
            }
        }
        return null;
    }
    
    void Refresh(GameObject obj, Vector3 pos, Quaternion rot, float angle)
    {
        obj.transform.position = pos;
        obj.transform.localScale = new Vector3(1f, 1f, 1f);
        obj.transform.rotation = rot;
        if (obj.TryGetComponent(out AProjectile aProjectile))
        {
            aProjectile.angle = angle;
        }
        else if (obj.TryGetComponent(out BlockedArrow blockedArrow))
        {
            blockedArrow.enemyX = angle;
        }
    }

    void ParentKiller(GameObject obj)
    {
        obj.transform.SetParent(null);
        obj.transform.localScale = new Vector3(1f, 1f, 1f);
        if (obj.TryGetComponent(out UsedArrow usedArrow))
        {
            DontDestroyOnLoad(obj);
            usedArrow.isEnemy = false;
        }
    }

}

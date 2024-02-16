using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] point;
    [SerializeField] GameObject[] pointer;

    void Awake()
    {
        //spawnPos = new List<Vector3>();
        //GameObject NewEnemy;
        //NewEnemy = Resources.Load("Enemy") as GameObject;
        //Instantiate(NewEnemy, spawnPos, Quaternion.identity);


        foreach (var i in pointer)
        {
            if (i.GetComponent<PointerSignal>().level <= KeyManager.Instance.level)
            {
                Vector3 pos = i.transform.position;
                pos.z = 1f;
                GameObject enemyObject = Instantiate(enemy, pos, Quaternion.identity);
                i.SetActive(false);
            }
            else
            {
                i.SetActive(false);
            }
        }

        //Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}

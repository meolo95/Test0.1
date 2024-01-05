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

    void Start()
    {
        //spawnPos = new List<Vector3>();
        //GameObject NewEnemy;
        //NewEnemy = Resources.Load("Enemy") as GameObject;
        //Instantiate(NewEnemy, spawnPos, Quaternion.identity);


        foreach (var i in point)
        {
            //GameObject enemyObject = Instantiate(enemy, i.position, Quaternion.identity);
            //enemyObject.SetActive(false);
        }

        //Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var i in pointer)
        {
            if (i.GetComponent<PointerSignal>().isSpawn == true)
            {
                if (i.GetComponent <PointerSignal>().level <= KeyManager.Instance.level)
                {
                    Vector3 pos = i.transform.position;
                    pos.z = 1f;
                    GameObject enemyObject = Instantiate(enemy, pos, Quaternion.identity);
                    i.GetComponent<PointerSignal>().isSpawn = false;
                    i.SetActive(false);
                }
                else
                {
                    i.SetActive(false);
                }
                
            }
        }
        

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] point;
    [SerializeField] PointerSignal pointer;

    void Start()
    {
        //spawnPos = new List<Vector3>();
        //GameObject NewEnemy;
        //NewEnemy = Resources.Load("Enemy") as GameObject;
        //Instantiate(NewEnemy, spawnPos, Quaternion.identity);


        foreach (var i in point)
        {
            GameObject enemyObject = Instantiate(enemy, i.position, Quaternion.identity);
            enemyObject.SetActive(false);
        }

        Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}

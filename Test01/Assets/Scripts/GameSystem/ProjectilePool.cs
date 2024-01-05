using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;

   // public IObjectPool<GameObject> Pool {  get; private set; }

    public int defaultCapacity;
    public int maxPoolSize;
    public GameObject projectile;


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

    private void Init()
    {
        //Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
            //OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);
        for (int i = 0; i < defaultCapacity; i++)
        {
            //ArrowProjectile arrow = CreatePooledItem().GetComponent<ArrowProjectile>();
            //arrow.Pool.Release(arrow.gameObject);
        }

    }

    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(projectile);
        //poolGo.GetComponent<ArrowProjectile>().Pool = this.Pool;
        return poolGo;
    }

    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

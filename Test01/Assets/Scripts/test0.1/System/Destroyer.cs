using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public static Destroyer Instance = null;


    [SerializeField] GameObject[] Boom;

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

    }
    public void GoodBye()
    {
        foreach(var obj in Boom)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}

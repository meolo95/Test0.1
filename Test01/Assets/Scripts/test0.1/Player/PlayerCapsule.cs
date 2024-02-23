using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapsule : MonoBehaviour
{
    public static PlayerCapsule Instance = null;
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
            //Destroy(Instance);
            //Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
}

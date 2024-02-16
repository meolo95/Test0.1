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
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

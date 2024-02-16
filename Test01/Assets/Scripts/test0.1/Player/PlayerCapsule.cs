using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapsule : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

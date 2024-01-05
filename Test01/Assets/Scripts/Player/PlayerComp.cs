using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComp : MonoBehaviour
{
    public static PlayerComp Instance = null;
    // Start is called before the first frame update


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != null & Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

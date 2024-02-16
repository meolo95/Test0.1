using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSignal : MonoBehaviour
{

    public bool isSpawn = false;
    [SerializeField] public float level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //isSpawn = true;
        }
    }

}

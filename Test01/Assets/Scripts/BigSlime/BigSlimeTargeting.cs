using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSlimeTargeting : MonoBehaviour
{

    [SerializeField] BigSlimeMove bigSlimeMove;
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
        if ( collision.tag == "Player")
        {
            bigSlimeMove.isTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            bigSlimeMove.isTarget = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordGoblinSense : MonoBehaviour
{
    EnemySenseRoaming roam;
    // Start is called before the first frame update
    void Start()
    {
        roam = GetComponentInParent<EnemySenseRoaming>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roam.isSense = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            roam.isSense = false;
        }
    }
}

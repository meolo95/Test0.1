using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMTargeting : MonoBehaviour
{
    [SerializeField] GameObject GM;
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
        if (collision.gameObject.CompareTag("Player") && GM.GetComponent<GMRun>().isTarget == false)
        {
            GM.GetComponent<GMRun>().isTarget = true;
        }
    }
}

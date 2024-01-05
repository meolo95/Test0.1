using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WGTrigger : MonoBehaviour
{
    [SerializeField] GameObject WG;
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
        if (collision.gameObject.CompareTag("Player") && WG.GetComponent<WeakGround>().check == false)
        {
            WG.GetComponent<WeakGround>().isIn = true;
            WG.GetComponent<WeakGround>().StopCo();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WG.GetComponent<WeakGround>().isIn = false;
            WG.GetComponent<WeakGround>().StartCo();
        }
    }
}

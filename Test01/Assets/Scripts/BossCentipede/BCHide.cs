using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCHide : MonoBehaviour
{
    [SerializeField] GameObject BC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BC.GetComponent<BCTargeting>().isHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BC.GetComponent<BCTargeting>().isHide = false;
        }
    }
}

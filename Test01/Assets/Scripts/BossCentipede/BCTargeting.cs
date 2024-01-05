using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCTargeting : MonoBehaviour
{
    [SerializeField] GameObject BC;

    public bool isHide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isHide == false)
        {
            if (BC.GetComponent<BCMove>().isTarget == false)
            {
                BC.GetComponent<BCMove>().isTarget = true;
                BC.GetComponent<BCMove>().playerPos = PlayerLocation.Instance.PlayerPosition();
                BC.GetComponent<BCMove>().thisPos = BC.transform.position;
                BC.GetComponent<BCMove>().StartCo();
            }
            
        }
    }
}

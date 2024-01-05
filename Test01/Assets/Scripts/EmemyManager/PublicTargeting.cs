using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicTargeting : MonoBehaviour
{
    [SerializeField] TargeterMove targeterMove;

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
            targeterMove.rigid.velocity = Vector3.zero;
            targeterMove.isTarget = true;
            targeterMove.isReady = true;
            targeterMove.rigid.velocity = Vector3.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targeterMove.GetTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targeterMove.isTarget = false;
            targeterMove.isReady = false;
        }
    }
}

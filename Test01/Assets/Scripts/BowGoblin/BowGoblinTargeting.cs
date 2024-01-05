using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BowGoblinTargeting : MonoBehaviour
{
    [SerializeField] BowGoblin bowGoblin;
    [SerializeField] BowGoblinMove bowGoblinMove;

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
            bowGoblinMove.rigid.velocity = Vector3.zero;
            bowGoblinMove.isTarget = true;
            bowGoblinMove.isReady = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bowGoblinMove.GoblinGetTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bowGoblinMove.isTarget = false;
            bowGoblinMove.isReady = false;
            bowGoblin.bowGoblinAnim.SetBool("IsIdle", true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpearGoblinTargeting : MonoBehaviour
{
    [SerializeField] SpearGoblin spearGoblin;
    [SerializeField] SpearGoblinMove spearGoblinMove;

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
            spearGoblinMove.rigid.velocity = Vector2.zero;
            spearGoblinMove.isTarget = true;
            spearGoblinMove.isReady = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spearGoblinMove.GoblinGetTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spearGoblinMove.isTarget = false;
            spearGoblinMove.isReady = false;
            spearGoblin.spearGoblinAnim.SetBool("IsIdle", true);
        }
    }
}

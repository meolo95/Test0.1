using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGoblinTargeting : MonoBehaviour
{
    [SerializeField] GameObject swordGoblin;
    public float target;
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
            if (swordGoblin.GetComponent<SwordGoblin>().isTarget == false)
            {
                swordGoblin.GetComponent<SwordGoblin>().isTarget = true;
                target = PlayerLocation.Instance.PlayerPosition().x;
                swordGoblin.GetComponent<SwordGoblinAttack>().StartAttack(target);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (swordGoblin.GetComponent<SwordGoblin>().isTarget == false)
            {
                swordGoblin.GetComponent<SwordGoblin>().isTarget = true;
                target = PlayerLocation.Instance.PlayerPosition().x;
                swordGoblin.GetComponent<SwordGoblinAttack>().StartAttack(target);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //swordGoblin.GetComponent<SwordGoblinAttack>().StopAttack(target);
        }
    }
}

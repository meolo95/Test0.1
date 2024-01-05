using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTargeting : MonoBehaviour
{
    //[SerializeField] Bat bat;
    //[SerializeField] BatMove batmove;
    [SerializeField] GameObject bee;
    [SerializeField] Bee bee2;
    // Start is called before the first frame update
    void Start()
    {
        //bat = GetComponent<Bat>();
        //batmove = GetComponent<BatMove>();
        //bat.GetComponent<BatMove>().GetTarget();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bee2.beeAnim.SetBool("IsTarget", true);
            bee2.beeAnim.SetBool("IsIdle", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bee.GetComponent<BeeMove>().GetTarget();
            bee.GetComponent<BeeMove>().isTargeting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bee.GetComponent<BeeMove>().isTargeting = false;

            bee2.beeAnim.SetBool("IsTarget", false);
            bee2.beeAnim.SetBool("IsIdle", true);
        }
    }
}

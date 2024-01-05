using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGoblinTargeting : MonoBehaviour
{

    [SerializeField] GameObject meleeGoblin;
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
            if (meleeGoblin.GetComponent<MeleeGoblin>().isTarget == false)
            {
                meleeGoblin.GetComponent<MeleeGoblin>().isTarget = true;

                meleeGoblin.GetComponent<MeleeGoblin>().StartCo();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (meleeGoblin.GetComponent<MeleeGoblin>().isTarget == false)
            {
                meleeGoblin.GetComponent<MeleeGoblin>().isTarget = true;

                meleeGoblin.GetComponent<MeleeGoblin>().StartCo();
            }
        }
    }


}

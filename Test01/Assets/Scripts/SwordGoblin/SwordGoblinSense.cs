using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordGoblinSense : MonoBehaviour
{
    [SerializeField] GameObject swordGoblin;
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
            swordGoblin.GetComponent<SwordGoblin>().isSense = true;
            swordGoblin.GetComponent<SwordGoblin>().anim.SetBool("IsSense", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            swordGoblin.GetComponent<SwordGoblin>().isSense = false;
            swordGoblin.GetComponent<SwordGoblin>().anim.SetBool("IsSense", false);
        }
    }
}

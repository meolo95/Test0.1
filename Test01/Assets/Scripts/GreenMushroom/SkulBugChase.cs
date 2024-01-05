using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkulBugChase : MonoBehaviour
{
    [SerializeField] GameObject SB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SB.GetComponent<GMRun>().isTarget = false;
            SB.GetComponent<GMRun>().anim.SetBool("IsRun", false);
        }
    }

}

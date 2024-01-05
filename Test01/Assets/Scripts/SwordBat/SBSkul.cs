using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBSkul : MonoBehaviour
{
    [SerializeField] GameObject SB;
    [SerializeField] GameObject skul;
    GameObject drop;

    [SerializeField] bool isDroper;

    public bool isTarget;
    bool isDrop;
    // Start is called before the first frame update
    void Start()
    {
        if (isDroper)
        {
            drop = Instantiate(skul, transform.position, Quaternion.identity);
            drop.GetComponent<GMRun>().isOn = false;
        }
        //drop.GetComponent<GMRun>().rigid.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTarget == false && isDroper == true)
        {
            SkulCatch();
            drop.GetComponent<GMRun>().rigid.gravityScale = 0f;
        }
        if (isTarget == true || SB.GetComponent<Enemy>().isAlive == false)
        {
            if (drop != null)
            {
                if (isDrop == false)
                {
                    drop.GetComponent<GMRun>().rigid.gravityScale = 1f;
                    isDrop = true;
                    drop.GetComponent<GMRun>().isOn = true;
                }
            }
            
        }
    }

    void SkulCatch()
    {
        drop.transform.position = transform.position + Vector3.down * 0.7f;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowGoblinThrow : MonoBehaviour
{
    [SerializeField] GameObject spear;
    BowGoblinMove bowGoblinMove;
    // Start is called before the first frame update
    void Start()
    {
        bowGoblinMove = GetComponent<BowGoblinMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowArrow()
    {
        Vector3 throwpos = bowGoblinMove.transform.position;
        Instantiate(spear, throwpos, Quaternion.identity);
        //GameObject spear = PoolManager.Instance.GetGo("GoblinArrow");
        //spear.transform.position = throwpos;

    }
}

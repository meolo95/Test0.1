using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGoblinThrow : MonoBehaviour
{
    [SerializeField] GameObject spear;
    SpearGoblinMove spearGoblinMove;
    // Start is called before the first frame update
    void Start()
    {
        spearGoblinMove = GetComponent<SpearGoblinMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowSpear()
    {
        Vector3 throwpos = spearGoblinMove.transform.position;
        Instantiate(spear, throwpos, Quaternion.identity);
    }
}

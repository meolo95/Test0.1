using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attached1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform weaponBone;
    Quaternion rot;
    [SerializeField] bool isArrow; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = weaponBone.position;
        if (isArrow == false)
        {
            rot = weaponBone.rotation;
            transform.rotation = rot;
        }
    }

    
}

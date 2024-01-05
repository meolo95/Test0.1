using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attached : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform weaponBone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = weaponBone.position;
        transform.rotation = weaponBone.rotation;
    }

    
}

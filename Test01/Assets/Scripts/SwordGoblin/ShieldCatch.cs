using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCatch : MonoBehaviour
{
    [SerializeField] GameObject Shielder;
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
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            if (Shielder.GetComponent<SwordGoblin>().isCool == false)
            {
                Shielder.GetComponent<SwordGoblin>().StartCo();
            }
        }
    }

}

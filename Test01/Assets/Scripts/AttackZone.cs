using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] public int demage;
    public bool isUsed = false;

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
        //collision.TryGetComponent<Health>(out Health )  
        if(collision.GetComponent<Health>() != null)
        {
            if (isUsed == false)
            {
                Health health = collision.GetComponent<Health>();
                health.DemageEnemy(demage);
                if (health.isSmall == false)
                {
                    isUsed = true;
                }
            }
        }
    }

}

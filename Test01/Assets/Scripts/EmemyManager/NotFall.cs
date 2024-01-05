using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFall : MonoBehaviour
{
    [SerializeField] public float x;
    [SerializeField] public float y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int Catch()
    {
        Vector3 raypos1 = new Vector3(transform.position.x + 0.4f + x, transform.position.y + y, transform.position.z);
        Vector3 raypos2 = new Vector3(transform.position.x - 0.4f - x, transform.position.y + y, transform.position.z);
        Debug.DrawRay(raypos1, Vector3.down);
        Debug.DrawRay(raypos2, Vector3.down);

        RaycastHit2D rayHit1 = Physics2D.Raycast(raypos1, Vector3.down, 1f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(raypos2, Vector3.down, 1f, LayerMask.GetMask("Platform"));
        if (rayHit1.collider == null && rayHit2.collider != null)
        {
            return 1;
        }
        if (rayHit2.collider == null && rayHit1.collider != null)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}

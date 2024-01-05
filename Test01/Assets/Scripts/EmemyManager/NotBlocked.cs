using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBlocked : MonoBehaviour
{
    [SerializeField] float x;
    [SerializeField] float y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int Catch()
    {
        Vector3 raypos1 = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
        Debug.DrawRay(raypos1, Vector3.right);

        RaycastHit2D rayHit1 = Physics2D.Raycast(raypos1, Vector3.right, 1f, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHit2 = Physics2D.Raycast(raypos1, Vector3.left, 1f, LayerMask.GetMask("Platform"));
        if (rayHit1.collider != null || rayHit2.collider != null)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

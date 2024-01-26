using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGround : MonoBehaviour
{
    [SerializeField] GameObject usedProjectile;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            GameObject sharedParent = new GameObject("Father");
            sharedParent.transform.position = collision.transform.position;
            sharedParent.transform.rotation = collision.transform.rotation;
            sharedParent.transform.SetParent(collision.gameObject.transform);

            Vector3 hitpos = transform.position;
            hitpos += transform.right * 0.2f;

            GameObject newArrows = Instantiate(usedProjectile, hitpos, transform.rotation);
            newArrows.transform.SetParent(sharedParent.transform, true);
            Destroy(gameObject);
        }
    }
}

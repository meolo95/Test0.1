using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePlat : MonoBehaviour
{
    [SerializeField] GameObject usedSpike;
    [SerializeField] bool isPlat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Platform")
        {
            if (isPlat == false)
            {
                GameObject sharedParent = new GameObject("Father");
                sharedParent.transform.position = otherObject.transform.position;
                sharedParent.transform.rotation = otherObject.transform.rotation;
                sharedParent.transform.SetParent(otherObject.gameObject.transform);

                Vector3 hitpos = transform.position;

                GameObject newArrows = Instantiate(usedSpike, hitpos, transform.rotation);
                newArrows.transform.SetParent(sharedParent.transform, true);
                Destroy(gameObject);
            }
            if (isPlat == true)
            {
                Destroy(gameObject);
            }


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownArrow : MonoBehaviour
{

    [SerializeField] GameObject usedArrow;
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
            GameObject sharedParent = new GameObject("Father");
            sharedParent.transform.position = otherObject.transform.position;
            sharedParent.transform.rotation = otherObject.transform.rotation;
            sharedParent.transform.SetParent(otherObject.gameObject.transform);

            Vector3 hitpos = transform.position;
            hitpos += transform.right * 0.5f;

            GameObject newArrows = Instantiate(usedArrow, hitpos, transform.rotation);
            newArrows.transform.SetParent(sharedParent.transform, true);
            Destroy(gameObject);


        }
    }
}

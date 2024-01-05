using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownSpear : MonoBehaviour
{

    [SerializeField] GameObject usedSpear;
    [SerializeField] bool isPlat;
    Pooler pooler;
    [SerializeField] string obj;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<Pooler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        pooler.ReleaseObject();
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
                hitpos += transform.right * 0.5f;

                GameObject newArrows = Instantiate(usedSpear, hitpos, transform.rotation);
                //GameObject newArrows = PoolManager.Instance.GetGo(obj);
                //newArrows.transform.position = hitpos;
                //newArrows.transform.rotation = transform.rotation;
                newArrows.transform.SetParent(sharedParent.transform, true);
                Destroy(gameObject);
                //pooler.ReleaseObject();
            }
            if (isPlat == true)
            {
                Destroy(gameObject, 0.1f);
                //StartCoroutine(Wait());
            }


        }
    }
}

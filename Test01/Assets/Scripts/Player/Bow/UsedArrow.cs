using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedArrow : MonoBehaviour
{
    public bool isEnemy;
    Pooler pooler;
    public bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<Pooler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isEnemy == false)
        {
            PlayerLocation.Instance.UseArrow(1);
            if (isGround)
            {
                Destroy(gameObject);
            }
            else
            {
                //pooler.ReleaseObject();
                Destroy(gameObject);
            }
        }
    }
}

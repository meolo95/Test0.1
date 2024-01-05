using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTarget : MonoBehaviour
{
    [SerializeField] GameObject spider;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            spider.GetComponent<SpiderWalk>().isTarget = true;

            spider.GetComponent<SpiderWalk>().rigid.gravityScale = 1f;

            spider.GetComponent<SpiderWalk>().notFall.y = 0;
        }
    }
}

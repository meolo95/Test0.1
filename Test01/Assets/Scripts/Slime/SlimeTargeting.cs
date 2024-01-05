using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlimeTargeting : MonoBehaviour
{
    [SerializeField] SlimeChase slimechase;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        //chase = GameObject.Find("ChaseZone").GetComponent<Chase>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slimechase.ischasing = true;

        }

    }

}

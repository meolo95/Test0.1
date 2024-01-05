using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeChase : MonoBehaviour
{
    [SerializeField] Slime slime;
    public bool ischasing = false;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ischasing == true)
            {
                slime.follow = true;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slime.follow = false;
        }
    }

}

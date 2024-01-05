using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBlock : MonoBehaviour
{
    [SerializeField] GameObject stone;
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
        if (collision.gameObject.CompareTag("Box"))
        {
            stone.GetComponent<MovingStone>().isTargetX = false;
            stone.GetComponent<MovingStone>().isTargetY = false;
        }
    }
}

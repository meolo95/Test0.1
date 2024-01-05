using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStoneTargeting2 : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            if (stone.GetComponent<MovingStone>().isTargetX && stone.GetComponent<MovingStone>().isTargetY != true)
            {
                stone.GetComponent<MovingStone>().isTargetX = true;
                stone.GetComponent<MovingStone>().pos = PlayerLocation.Instance.PlayerPosition();
                if (PlayerLocation.Instance.PlayerPosition().x > stone.transform.position.x)
                {
                    stone.GetComponent<MovingStone>().xUp = true;
                }
                else if (PlayerLocation.Instance.PlayerPosition().x < stone.transform.position.x)
                {
                    stone.GetComponent<MovingStone>().xUp = false;
                }
            }
            

        }
    }
}

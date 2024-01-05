using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStoneTargeting : MonoBehaviour
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
                stone.GetComponent<MovingStone>().isTargetY = true;
                stone.GetComponent<MovingStone>().pos = PlayerLocation.Instance.PlayerPosition();
                if (PlayerLocation.Instance.PlayerPosition().y > stone.transform.position.y)
                {
                    stone.GetComponent<MovingStone>().yUp = true;
                }
                else if (PlayerLocation.Instance.PlayerPosition().y < stone.transform.position.y)
                {
                    stone.GetComponent<MovingStone>().yUp = false;
                }
            }
            

        }
    }
}

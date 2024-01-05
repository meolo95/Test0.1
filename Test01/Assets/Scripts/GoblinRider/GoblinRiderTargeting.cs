using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRiderTargeting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject goblinRider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && goblinRider.GetComponent<GoblinRider>().isRushing == false)
        {
            goblinRider.GetComponent<GoblinRider>().isTarget = true;


            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {
                goblinRider.GetComponent<GoblinRider>().isRight = true;

            }
            else if (transform.position.x >= PlayerLocation.Instance.PlayerPosition().x)
            {
                goblinRider.GetComponent<GoblinRider>().isRight = false;

            }
            goblinRider.GetComponent<GoblinRider>().StartCo();

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && goblinRider.GetComponent<GoblinRider>().isRushing == false)
        {
            goblinRider.GetComponent<GoblinRider>().isTarget = true;


            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {
                goblinRider.GetComponent<GoblinRider>().isRight = true;

            }
            else if (transform.position.x >= PlayerLocation.Instance.PlayerPosition().x)
            {
                goblinRider.GetComponent<GoblinRider>().isRight = false;

            }
            goblinRider.GetComponent<GoblinRider>().StartCo();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            goblinRider.GetComponent<GoblinRider>().isTarget = false;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarTargeting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject boar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && boar.GetComponent<Boar>().isRushing == false)
        {
            boar.GetComponent<Boar>().isTarget = true;


            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {
                boar.GetComponent<Boar>().isRight = true;

            }
            else if (transform.position.x >= PlayerLocation.Instance.PlayerPosition().x)
            {
                boar.GetComponent<Boar>().isRight = false;

            }

            boar.GetComponent<Boar>().StartCo();
            //boar.GetComponent<Boar>().anim.SetBool("IsRush", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && boar.GetComponent<Boar>().isRushing == false)
        {
            boar.GetComponent<Boar>().isTarget = true;


            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {
                boar.GetComponent<Boar>().isRight = true;

            }
            else if (transform.position.x >= PlayerLocation.Instance.PlayerPosition().x)
            {
                boar.GetComponent<Boar>().isRight = false;

            }

            boar.GetComponent<Boar>().StartCo();
            //boar.GetComponent<Boar>().anim.SetBool("IsRush", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boar.GetComponent<Boar>().isTarget = false;
        }
    }

}

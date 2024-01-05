using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BoarCollision : MonoBehaviour
{

    [SerializeField] GameObject boar;
    bool isCoring;
    bool wait;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



IEnumerator CollisionStun()
    {
        boar.GetComponent<Boar>().anim.SetBool("IsRush", false);
        isCoring = true;
        yield return new WaitForSeconds(2f);
        if (wait)
        {
            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {

                boar.GetComponent<Boar>().isRight = true;

            }
            else if (transform.position.x >= PlayerLocation.Instance.PlayerPosition().x)
            {
                boar.GetComponent<Boar>().isRight = false;

            }
            wait = false;
        }
        isCoring = false;
        boar.GetComponent<Boar>().isColl = false;
        boar.GetComponent<Boar>().isRushing = false;
        //boar.GetComponent<Boar>().StartCo();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            boar.GetComponent<Boar>().rigid.velocity = Vector2.zero;

            if (boar.GetComponent<Boar>().isRight)
            {
                boar.GetComponent<Boar>().rigid.AddForce(new Vector2(-3f, 3f), ForceMode2D.Impulse);
            }
            else
            {
                boar.GetComponent<Boar>().rigid.AddForce(new Vector2(3f, 3f), ForceMode2D.Impulse);
            }

            boar.GetComponent<Boar>().isColl = true;
            boar.GetComponent<Boar>().StopCo();
            wait = true;

            if (isCoring == false)
            {
                StartCoroutine(CollisionStun());
            }

        }
    }
}

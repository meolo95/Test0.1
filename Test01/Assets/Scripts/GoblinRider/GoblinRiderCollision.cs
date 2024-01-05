using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class GoblinRiderCollision : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject goblinRider;
    public bool wait = false;
    bool isCoring;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator collidor;
    void StartCol()
    {
        collidor = CollisionStun();
        StartCoroutine(collidor);
    }
    void StopCol()
    {
        collidor = CollisionStun();
        StopCoroutine(collidor);
    }


    IEnumerator CollisionStun()
    {
        goblinRider.GetComponent<GoblinRider>().anim.SetBool("IsRush", false);
        isCoring = true;
        yield return new WaitForSeconds(4f);
        if (wait == true)
        {
            
            if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
            {

                goblinRider.GetComponent<GoblinRider>().isRight = true;

            }
            else if (transform.position.x >= PlayerLocation.Instance.PlayerPosition().x)
            {
                goblinRider.GetComponent<GoblinRider>().isRight = false;

            }
            goblinRider.GetComponent<GoblinRider>().isColl = false;
            goblinRider.GetComponent<GoblinRider>().isRushing = false;
            wait = false;
        }
        isCoring = false;
        yield return null;



    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform" && goblinRider.GetComponent<GoblinRider>().isRushing == true)
        {
            goblinRider.GetComponent<GoblinRider>().rigid.velocity = Vector2.zero;

            if (goblinRider.GetComponent<GoblinRider>().isRight)
            {
                goblinRider.GetComponent<GoblinRider>().rigid.AddForce(new Vector2(-3f, 3f), ForceMode2D.Impulse);
            }
            else
            {
                goblinRider.GetComponent<GoblinRider>().rigid.AddForce(new Vector2(3f, 3f), ForceMode2D.Impulse);
            }



            goblinRider.GetComponent<GoblinRider>().isColl = true;
            goblinRider.GetComponent<GoblinRider>().StopCo();
            wait = true;
            if (isCoring == false)
            {
                StartCol();
            }

        }
    }
}

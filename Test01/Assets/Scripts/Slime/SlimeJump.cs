using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeJump : MonoBehaviour
{
    [SerializeField] Slime slime;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SlimeJumping()
    {
        slime.isJumping = true;
        yield return new WaitForSeconds(slime.delay);
        if (slime.readytojump)
        {
            slime.SlimeJump();
        }
        slime.isJumping = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            //StopCoroutine(SlimeJumping());
            slime.isground = true;
            slime.readytojump = true;
            //slime.lasttime = Time.time;
            if (slime.isJumping == false)
            {
                StartCoroutine(SlimeJumping());
            }
            slime.enemy.isHit = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            //StopCoroutine(SlimeJumping());
            slime.GetTarget();
            slime.readytojump = false;
            slime.isground = false;
            
        }
    }
}

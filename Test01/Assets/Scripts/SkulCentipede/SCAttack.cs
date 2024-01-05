using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCAttack : MonoBehaviour
{
    SCSense sense;
    Animator anim;
    public Enemy enemy;
    [SerializeField] GameObject spike;

    
    // Start is called before the first frame update
    void Start()
    {
        sense = GetComponent<SCSense>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAlive == false)
        {
            StopAllCoroutines();
            anim.SetBool("IsDie", true);
        }
        
    }


    public void StartAttack()
    {
        StartCoroutine(Spike());
    }

    IEnumerator Spike()
    {
        anim.SetBool("IsAttack", true);
        yield return new WaitForSeconds(1f);
        Instantiate(spike, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(spike, transform.position + Vector3.down, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Instantiate(spike, transform.position + Vector3.down * 2f, Quaternion.identity);
        anim.SetBool("IsAttack", false);
        yield return new WaitForSeconds(2f);
        StartAttack();
    }
}

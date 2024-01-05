using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBAttack : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject knife;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartAttack()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        anim.SetBool("IsAttack", true);
        yield return new WaitForSeconds(1.5f);
        Instantiate(knife, transform.position, Quaternion.Euler(0f, 0f, -140f));
        //GameObject knife = PoolManager.Instance.GetGo("Sword");
        //knife.transform.position = transform.position;
        //knife.transform.rotation = Quaternion.Euler(0f, 0f, -140f);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsAttack", false);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Attack());
    }
}

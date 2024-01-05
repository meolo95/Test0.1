using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInst : MonoBehaviour
{
    [SerializeField] GameObject rock;
    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Summon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Summon()
    {
        int rand = Random.Range(-1, 2);
        Instantiate(rock, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delay + rand);
        StartCoroutine(Summon());
    }
}

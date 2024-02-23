using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRepeat : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Repeat());
    }

    void Update()
    {
        
    }

    IEnumerator Repeat()
    {
        yield return new WaitForSeconds(3f);
        SoundManager.Instance.SummonPlay("GhostGrowl", transform.position);
        StartCoroutine(Repeat());
    }
}

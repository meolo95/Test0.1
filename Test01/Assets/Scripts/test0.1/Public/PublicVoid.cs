using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PublicVoid : MonoBehaviour
{
    public static PublicVoid Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GetDelay(float delay)
    {
        if (IEdelay == null)
        {
            delayStart(delay);
        }
    }

    IEnumerator IEdelay;

    void delayStart(float delay)
    {
        IEdelay = Getdelay(delay);
        StartCoroutine(IEdelay);
    }

    void delayStop()
    {
        if (IEdelay != null)
        {
            StopCoroutine(IEdelay);
        }
    }

    IEnumerator Getdelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        yield return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShielding : EnemyManage, IEtc
{
    [SerializeField] float delay;


    public void Etc()
    {
        if (IEdelay == null)
        {
            delayStart(delay);
        }
        rigid.velocity = Vector3.zero;
        if (transform.position.x < PlayerManage.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerManage.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(-1f, 1f);
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
        Debug.Log("Upshield");
        AnimSetTrue("IsShield");
        yield return new WaitForSeconds(delay);
        AnimSetFalse("IsShield");
        IEdelay = null;
    }

}

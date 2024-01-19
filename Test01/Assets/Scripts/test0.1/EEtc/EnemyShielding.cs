using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShielding : MonoBehaviour, IEtc
{
    Rigidbody2D rigid;
    Animator anim;
    [SerializeField] float delay;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Etc()
    {
        if (IEdelay == null)
        {
            delayStart(delay);
        }
        rigid.velocity = Vector3.zero;
        if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x)
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
        anim.SetBool("IsShield", true);
        yield return new WaitForSeconds(delay);
        anim.SetBool("IsShield", false);
        IEdelay = null;
    }

}

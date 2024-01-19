using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitByE : PlayerBehaviour, IHit
{
    public GameObject hitObject;
    [SerializeField] float stun;
    [SerializeField] float time;
    [SerializeField] float delay;

    SpriteRenderer[] spriteRenderer;

    protected override void Awake()
    {
        base.Awake();

        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }
    public void Hit()
    {
        StartHit();
    }

    IEnumerator IEHit;

    void StartHit()
    {
        if (IEHit == null)
        {
            IEHit = EHit();
            StartCoroutine(IEHit);
        }
    }

    IEnumerator EHit()
    {
        SetColor(0.6f);
        PState.states[PlayerState.devine] = true;
        rigid.velocity = Vector3.zero;
        if (hitObject.transform.position.x < transform.position.x)
        {
            rigid.AddForce(new Vector2(1, 1) * stun, ForceMode2D.Impulse);
        }
        else if (hitObject.transform.position.x >= transform.position.x)
        {
            rigid.AddForce(new Vector2(-1, 1) * stun, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(time);
        PState.states[PlayerState.hit] = false;
        yield return new WaitForSeconds(delay);
        SetColor(1f);
        if (!PState.states[PlayerState.roll])
        {
            PState.states[PlayerState.devine] = false;
        }
        IEHit = null;
    }

    void SetColor(float color)
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].color = new Color(1f, 1f, 1f, color);
        }
    }
}

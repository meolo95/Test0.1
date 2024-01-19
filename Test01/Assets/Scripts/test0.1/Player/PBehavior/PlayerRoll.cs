using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerRoll : PlayerBehaviour, IRoll
{
    [SerializeField] float rollSpeed;

    public void Roll()
    {
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.Roll]))
        {
            if (IERoll == null)
            {
                RollStart();
            }
        }
    }

    IEnumerator IERoll;
    void RollStart()
    {
        IERoll = ERoll();
        StartCoroutine(IERoll);
    }

    IEnumerator ERoll()
    {
        anim.SetBool("IsRolling", true);
        PState.states[PlayerState.roll] = true;
        PState.states[PlayerState.devine] = true;
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector2(PlayerLocation.Instance.dir * rollSpeed, 0f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("IsRolling", false);
        PState.states[PlayerState.roll] = false;
        PState.states[PlayerState.devine] = false;
        yield return new WaitForSeconds(0.5f);
        IERoll = null;
    }
}

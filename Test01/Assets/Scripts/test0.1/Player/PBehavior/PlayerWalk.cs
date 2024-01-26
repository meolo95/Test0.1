using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerBehaviour,IWalk
{
    [SerializeField] float walkSpeed;

    public void Walk()
    {
        if (Input.GetKey(KeySetting.keys[KeyAction.Left]))
        {
            SoundManager.Instance.OnlyPlay("Walk");
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
            transform.localScale = new Vector3(-1, 1, 1);
            rigid.velocity = new Vector2(-1 * walkSpeed, rigid.velocity.y);
            PlayerManage.Instance.dir = -1;
            PState.states[PlayerState.walk] = true;
        }
        else if (Input.GetKey(KeySetting.keys[KeyAction.Right]))
        {
            SoundManager.Instance.OnlyPlay("Walk");
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
            transform.localScale = new Vector3(1, 1, 1);
            rigid.velocity = new Vector2(1 * walkSpeed, rigid.velocity.y);
            PlayerManage.Instance.dir = 1;
            PState.states[PlayerState.walk] = true;
        }
        else
        {
            //anim.SetBool("IsWalking", false);
            PState.states[PlayerState.walk] = false;
        }
    }
}

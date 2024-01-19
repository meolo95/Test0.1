using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyBehavior : PlayerBehaviour
{
    [SerializeField] float rollSpeed;
    [SerializeField] float rollDelay;
    [SerializeField] float jumpSpeed;


    void KeyBehavior()
    {
    }

    public void Roll()
    {
    }

    public void Jump()
    {
    }

    public void Melee()
    {

    }

    IEnumerator IIEJump;
    void JumpStart()
    {
        IIEJump = IEJump();
        StartCoroutine(IIEJump);
    }
    void JumpStop()
    {
        StopCoroutine(IIERoll);
    }

    IEnumerator IEJump()
    {
        rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        yield return null;
    }





    IEnumerator IIERoll;
    void RollStart()
    {
        IIERoll = IERoll();
        StartCoroutine(IIERoll);
    }
    void RollStop()
    {
        StopCoroutine(IIERoll);
    }

    IEnumerator IERoll()
    {
        yield return new WaitForSeconds(rollDelay);
        IIERoll = null;
    }
}

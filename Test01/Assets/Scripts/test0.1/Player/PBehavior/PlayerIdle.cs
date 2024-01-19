using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerBehaviour, IIdle
{
    public void Idle()
    {
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsIdle", true);
    }
}

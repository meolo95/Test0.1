using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : PlayerBehaviour, IPDie
{
    public void Die()
    {
        anim.SetBool("IsDie", true);
    }
}

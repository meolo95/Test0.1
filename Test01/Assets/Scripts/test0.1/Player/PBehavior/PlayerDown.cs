using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDown : PlayerBehaviour, IDown, IUp
{

    public void Down()
    {
        if (Input.GetKey(KeySetting.keys[KeyAction.Down]))
        {
            anim.SetBool("IsDown", true);
            PState.states[PlayerState.down] = true;
            Vector2 downsize = new Vector2(Col.size.x, 0.5f);
            Col.size = downsize;
            
        }
        else
        {
            anim.SetBool("IsDown", false);
            PState.states[PlayerState.down] = false;
            Col.size = Colsize;
        }

    }

    public void Up()
    {
        anim.SetBool("IsDown", false);
        PState.states[PlayerState.down] = false;
        Col.size = Colsize;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGB : PlayerBehaviour,IIdle, IWalk, IDown, IHook
{

    public override void Update()
    {
        base.Update();
        DownBehavior();
    }

    void DownBehavior()
    {
        switch (keydowncommand)
        {
            case PlayerKeyDownCommand.idle:
                Idle();
                break;
            case PlayerKeyDownCommand.walkL:
                Walk();
                break;
            case PlayerKeyDownCommand.walkR:
                Walk();
                break;
            case PlayerKeyDownCommand.down:
                Down();
                break;
        }
    }

    public void Idle()
    {
        transform.localScale = new Vector3(direction, 1f, 1);
    }
    public void Walk()
    {
        if (keydowncommand == PlayerKeyDownCommand.walkL)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rigid.velocity = new Vector2(-1 * player.GetSpeed(), rigid.velocity.y);
            direction = -1;
            
        }
        else if (keydowncommand == PlayerKeyDownCommand.walkR)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rigid.velocity = new Vector2(1 * player.GetSpeed(), rigid.velocity.y);
            direction = 1;
        }
    }
    public void Down()
    {
        transform.localScale = new Vector3(direction, 0.5f, 1);
    }
    public void Hook()
    {

    }
}

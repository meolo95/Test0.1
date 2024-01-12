using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    protected int direction = 1;

    protected Rigidbody2D rigid;

    protected PlayerCommand command;
    protected PlayerLife life;

    protected PlayerKeyDownCommand keydowncommand;
    protected PlayerKeyCommand keycommand;
    protected PlayerKeyUpDownCommand keyupdowncommand;
    protected PlayerMeleeCommand meleecommand;

    protected PlayerManage player;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        player = new PlayerManage(20, 30, 5, 5);
    }

    public virtual void Update()
    {
        KeyCommand();
        Debug.Log(keydowncommand);
    }



    public void KeyCommand()
    {
        foreach (KeyAction key in Enum.GetValues(typeof(KeyAction)))
        {
            if (!Input.anyKey)
            {
                keydowncommand = PlayerKeyDownCommand.idle;
            }
            if (Input.GetKeyDown(KeySetting.keys[key]))
            {
                switch (key)
                {
                    case KeyAction.Attack1:
                        meleecommand = PlayerMeleeCommand.melee1;
                        break;
                    case KeyAction.Attack2:
                        meleecommand = PlayerMeleeCommand.melee2;
                        break;
                    case KeyAction.Jump:
                        keycommand = PlayerKeyCommand.jump;
                        break;
                    case KeyAction.Roll:
                        keycommand = PlayerKeyCommand.roll;
                        break;
                    case KeyAction.Up:
                        break;
                }
            }

            if (Input.GetKey(KeySetting.keys[key]))
            {
                switch (key)
                {
                    case KeyAction.Shoot:
                        keyupdowncommand = PlayerKeyUpDownCommand.draw;
                        break;
                    case KeyAction.Left:
                        keydowncommand = PlayerKeyDownCommand.walkL;
                        break;
                    case KeyAction.Right:
                        keydowncommand = PlayerKeyDownCommand.walkR;
                        break;
                    case KeyAction.Down:
                        keydowncommand = PlayerKeyDownCommand.down;
                        break;
                    case KeyAction.Hook:
                        keydowncommand = PlayerKeyDownCommand.hook;
                        break;
                    default:
                        break;


                }
            }

            if (Input.GetKeyUp(KeySetting.keys[key]))
            {
                switch (key)
                {
                    case KeyAction.Shoot:
                        keyupdowncommand = PlayerKeyUpDownCommand.none;
                        break;

                }
            }
        }
    }

}

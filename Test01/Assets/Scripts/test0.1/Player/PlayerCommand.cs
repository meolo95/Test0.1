using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCommand : MonoBehaviour
{
    IWalk walk;
    IRoll roll;
    IDown down;
    IJump jump;
    IDraw draw;
    IIdle idle;
    IMelee1 melee1;
    IMelee2 melee2;
    IUp up;
    IHook hook;
    IHit hit;
    IPDie die;

    public static PlayerLife plife;

    private void Awake()
    {
        for (int i = 0; i < (int)PlayerState.devine + 1; i++)
        {
            if (!PState.states.ContainsKey((PlayerState)i))
            {
                PState.states.Add((PlayerState)i, false);
            }
        }
        plife = PlayerLife.live;
        walk = GetComponent<IWalk>();
        roll = GetComponent<IRoll>();
        down = GetComponent<IDown>();
        jump = GetComponent<IJump>();
        draw = GetComponent<IDraw>();
        idle = GetComponent<IIdle>();
        melee1 = GetComponent<IMelee1>();
        melee2 = GetComponent<IMelee2>();
        up = GetComponent<IUp>();
        hook = GetComponent<IHook>();
        hit = GetComponent<IHit>();
        die = GetComponent<IPDie>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (plife == PlayerLife.live)
        {
            if (PState.states.Any(state => state.Value))
            {
                idle.Idle();
            }

            if (!PState.states[PlayerState.roll] && !PState.states[PlayerState.down] && !PState.states[PlayerState.hook] && !PState.states[PlayerState.melee] && !PState.states[PlayerState.hit])
            {
                walk.Walk();
            }

            if (!PState.states[PlayerState.hook] && !PState.states[PlayerState.melee] && !PState.states[PlayerState.hit])
            {
                roll.Roll();
            }


            if (!PState.states[PlayerState.roll] && !PState.states[PlayerState.hook] && !PState.states[PlayerState.melee] && !PState.states[PlayerState.draw] && !PState.states[PlayerState.hit])
            {
                down.Down();
            }
            else
            {
                up.Up();
            }


            if (!PState.states[PlayerState.down] && !PState.states[PlayerState.hook] && !PState.states[PlayerState.melee] && !PState.states[PlayerState.hit])
            {
                jump.Jump();
            }

            if (!PState.states[PlayerState.melee])
            {
                draw.Draw();
            }

            if (!PState.states[PlayerState.melee] && !PState.states[PlayerState.roll] && !PState.states[PlayerState.draw] && !PState.states[PlayerState.hook])
            {
                melee1.Melee1();
                melee2.Melee2();
            }

            if (!PState.states[PlayerState.down])
            {
                hook.Hook();
            }

            if (PState.states[PlayerState.hit] && !PState.states[PlayerState.roll])
            {
                hit.Hit();
            }
        }
        else
        {
            die.Die();
        }
    }
}

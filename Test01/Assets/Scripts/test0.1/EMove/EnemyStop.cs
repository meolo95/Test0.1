using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : MonoBehaviour, IMove
{
    Animator anim;
    int idle;

    int[] paint;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        idle = Animator.StringToHash("IsIdle");
        paint = new int[anim.parameterCount];
    }
    public void Move()
    {
        for (int i = 0; i < anim.parameterCount; i++)
        {
            paint[i] = Animator.StringToHash(anim.parameters[i].name);
            if (anim.parameters[i].name != "IsIdle")
            {
                anim.SetBool(paint[i], false);
            }
            else
            {
                anim.SetBool(paint[i], true);
            }

        }
    }

}

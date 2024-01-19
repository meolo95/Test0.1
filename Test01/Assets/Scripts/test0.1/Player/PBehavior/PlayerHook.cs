using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PlayerHook : PlayerBehaviour, IHook
{
    [SerializeField] LineRenderer line;

    Vector3 posRight;
    Vector3 posLeft;
    Vector3 plocation;

    [SerializeField] float speed;
    bool isLineMax;

    [SerializeField ] GameObject hook;
    HookControl hookControl;

    protected override void Awake()
    {
        base.Awake();
        hookControl = hook.GetComponent<HookControl>();
        //hook = hookControl.gameObject;

        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.transform.position);
        line.useWorldSpace = true;
    }

    public void Hook()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.transform.position);

        if (!PState.states[PlayerState.hook])
        {
            hook.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeySetting.keys[KeyAction.Hook]))
        {
            PState.states[PlayerState.hook] = true;
            hook.transform.position = transform.position;
            plocation = transform.position;
            posRight = transform.position + new Vector3(5f, 3f, 0f);
            posLeft = transform.position + new Vector3(-5f, 3f, 0f);
            PlayerLocation.Instance.hooking = true;
            hook.SetActive(true);
        }

        if (Input.GetKey(KeySetting.keys[KeyAction.Hook]) && isLineMax == false)
        {
            if (hookControl.isCol == false)
            {
                if (PlayerLocation.Instance.dir == 1)
                {

                    Vector3 dir = (posRight - plocation).normalized;
                    hookControl.rigid.velocity = dir * speed;
                }
                if (PlayerLocation.Instance.dir == -1)
                {

                    Vector3 dir = (posLeft - plocation).normalized;
                    hookControl.rigid.velocity = dir * speed;
                }

                if (Vector2.Distance(plocation, hook.transform.position) > 10)
                {
                    hook.transform.position = PlayerLocation.Instance.PlayerPosition();
                    hook.SetActive(false);
                    isLineMax = true;
                    hookControl.rigid.velocity = Vector3.zero;
                }
            }
            else if (hook.GetComponent<HookControl>().isCol == true)
            {
                hook.GetComponent<HookControl>().joint.enabled = true;
                hook.GetComponent<HookControl>().rigid.velocity = Vector3.zero;
            }
        }

        if (Input.GetKeyUp(KeySetting.keys[KeyAction.Hook]))
        {
            hookControl.joint.enabled = true;
            hookControl.joint.enabled = false;
            hook.transform.position = PlayerLocation.Instance.PlayerPosition();
            hookControl.isCol = false;
            isLineMax = false;
            PlayerLocation.Instance.hooking = false;
            hook.SetActive(false);
            PState.states[PlayerState.hook] = false;
        }
    }
}

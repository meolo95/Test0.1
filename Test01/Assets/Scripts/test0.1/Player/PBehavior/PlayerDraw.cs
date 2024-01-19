using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDraw : PlayerBehaviour, IDraw
{
    [SerializeField] GameObject arrow;
    GameObject aimingZone;
    float angle;

    public void Draw()
    {
        if (Input.GetKey(KeySetting.keys[KeyAction.Shoot]))
        {
            anim.SetBool("IsReady", true);
            PState.states[PlayerState.draw] = true;
            angle += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeySetting.keys[KeyAction.Shoot]))
        {
            anim.SetBool("IsReady", false);
            if (angle > 1f)
            {
                angle = 0.99f;
            }
            ArrowFire();
            angle = -0.5f;
            PState.states[PlayerState.draw] = false;


        }
    }

    void ArrowFire()
    {
        Vector3 pos = transform.position;
        pos.x += PlayerLocation.Instance.dir * 0.2f;
        GameObject Arrow = Instantiate(arrow, pos, Quaternion.identity);
        Arrow.GetComponent<AProjectile>().angle = angle;
    }
}

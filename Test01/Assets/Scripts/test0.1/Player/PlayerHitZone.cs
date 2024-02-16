using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitZone : MonoBehaviour
{
    PlayerHitByE hit;
    private void Awake()
    {
        hit = GetComponentInParent<PlayerHitByE>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (PlayerCommand.plife == PlayerLife.live)
        {
            if (!PState.states[PlayerState.devine])
            {
                if (other.gameObject.tag == "HitZone")
                {
                    hit.hitObject = other.gameObject;
                    PState.states[PlayerState.hit] = true;
                }

                if (other.gameObject.tag == "Projectile")
                {
                    hit.hitObject = other.gameObject;
                    PState.states[PlayerState.hit] = true;
                }
            }
        }
        
    }

}

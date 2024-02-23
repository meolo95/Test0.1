using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IHDetect
{
    bool Detect();
}
public class HDetect : MonoBehaviour, IHDetect
{
    bool isHit;

    public bool Detect()
    {
        return isHit;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AttackZone attackZone))
        {
            isHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AttackZone attackZone))
        {
            isHit = false;
        }
    }
}

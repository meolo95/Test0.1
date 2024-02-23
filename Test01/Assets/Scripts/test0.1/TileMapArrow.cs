using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TileMapArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (collision.TryGetComponent(out AttackZone attackZone))
        {
            if (attackZone.usedArrow != null)
            {
                ObjectPoolManager.Instance.ReleaseOnPull("Arrow", attackZone.key);
                Vector3 hitpos = collision.transform.position;
                hitpos += collision.transform.right * 0.1f;

                ObjectPoolManager.Instance.Get("UsedArrow", hitpos, collision.transform.rotation, 0);
            }
            


        }
    }
}

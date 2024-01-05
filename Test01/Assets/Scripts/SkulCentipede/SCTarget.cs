using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCTarget : MonoBehaviour
{
    [SerializeField] GameObject SC;
    [SerializeField] GameObject hitZone;
    bool isUp;

    [SerializeField] AudioClip clip;
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
        if (collision.gameObject.CompareTag("Player") && isUp == false)
        {
            SoundManager.Instance.SFXPlay("Growl", clip, 0.5f);
            SC.GetComponent<SCSense>().isTarget = true;
            isUp = true;
            hitZone.GetComponent<Health>().Shielding = false;
        }
    }
}

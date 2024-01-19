using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGroundCheck : MonoBehaviour
{
    //PlayerBehaviour behaviour;
    PlayerKeyBehavior behavior;
    PlayerBehaviour pb;

    private void Awake()
    {
        //behaviour = GetComponentInParent<PlayerBehaviour>();
        behavior = GetComponentInParent<PlayerKeyBehavior>();
        pb = GetComponentInParent<PlayerBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
        }
    }
}

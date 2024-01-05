using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeObsMove : MonoBehaviour
{
    [SerializeField] float speed;
    float angle = 1f;
    float timer;
    bool up;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (angle > 90f)
        {
            timer = 0f;
            up = false;
            angle = 89f;
        }
        
        if (angle < -90f)
        {
            timer = 0f;
            up = true;
            angle = -89f;
        }


        if (up == false)
        {
            timer += Time.deltaTime;
            float dev = angle;
            if (Mathf.Abs(angle) < 20)
            {
                dev = 20;
            }
            angle -= timer * speed / Mathf.Abs(dev);
        }
        if (up == true)
        {
            timer += Time.deltaTime;
            float dev = angle;
            if (Mathf.Abs(angle) < 20)
            {
                dev = 20;
            }
            angle += timer * speed / Mathf.Abs(dev);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}

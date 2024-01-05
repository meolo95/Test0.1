using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{

    Vector3 pos;
    Vector3 nowPos;

    [SerializeField] float num;
    [SerializeField] float nextNum;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        nowPos = transform.position;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos;
        pos.x -= Time.deltaTime * speed;
        if ( pos.x < num )
        {
            pos.x = nextNum;
        }

    }
}

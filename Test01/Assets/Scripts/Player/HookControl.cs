using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using static UnityEditor.PlayerSettings;

public class HookControl : MonoBehaviour
{
    public Rigidbody2D rigid;
    public DistanceJoint2D joint;


    public bool isCol;

    Vector3 plocation;
    Vector3 posRight;
    Vector3 posLeft;
    bool isLineMax;
    // Start is called before the first frame update


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isCol = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("hitit");
            isCol = true;
        }
    }

}

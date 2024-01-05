using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingStone : MonoBehaviour
{
    Rigidbody2D rigid;

    public bool isTargetX;
    public bool isTargetY;

    [SerializeField] float speed = 0f;

    public Vector3 pos;
    public bool yUp;
    public bool xUp;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTargetX)
        {
            if (transform.position.x == pos.x)
            {
                isTargetX = false;
            }
            if (xUp)
            {
                rigid.velocity = Vector2.left * speed;
            }
            else
            {
                rigid.velocity = Vector2.right * speed;
            }
        }
        if (isTargetY)
        {
            if (transform.position.y == pos.y)
            {
                isTargetY = false;
            }
            if (yUp)
            {
                rigid.velocity = Vector2.up * speed;
            }
            else
            {
                rigid.velocity = Vector2.down * speed;
            }
        }
        
        
    }

    
    
}

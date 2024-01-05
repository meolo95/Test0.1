using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float speed;
    Vector3 playerPos;
    Vector2 direction;
    Vector3 initialPosition;
    float angle;
    float gravity;
    float xTime;
    float yTime;
    float yrowDist;

    float xDistance;
    float yDistance;

    float xSpeed;
    [SerializeField] float ySpeed;
    [SerializeField] bool isArrow;

    public int demage;
    public int num = 4;


    bool isPlus;

    // Start is called before the first frame update

    

    private void OnEnable()
    {
        
    }

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerPos = PlayerLocation.Instance.PlayerPosition();

        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = 0f;
        //Destroy(gameObject, 10f);



        xDistance = playerPos.x - transform.position.x;
        yrowDist = playerPos.y - transform.position.y;
        yDistance = Mathf.Abs(playerPos.y - transform.position.y);

        gravity = 20;

        ArrowCheck();



        float timeToTop = ySpeed / gravity;
        float maxY = transform.position.y + (ySpeed * timeToTop) - (0.5f * gravity * timeToTop * timeToTop);
        float maxYDistance = Mathf.Abs(playerPos.y - maxY);
        yTime = Mathf.Sqrt(2 * maxYDistance / gravity) + timeToTop;
        xSpeed = xDistance / yTime;

        change(num);

        rigid.AddForce(new Vector2(xSpeed, ySpeed), ForceMode2D.Impulse);






        angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);


    }

    // Update is called once per frame
    void Update()
    {
        transform.right = rigid.velocity;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            //Destroy(gameObject);
        }
    }

    void ArrowCheck()
    {
        if (isArrow)
        {
            if (yrowDist <= 0.5f)
            {
                ySpeed = Mathf.Abs(xDistance) * ySpeed * 0.0417f;
            }
            if (yrowDist > 0.5f)
            {
                ySpeed = 12f;
            }
        }
    }


    public void change(int num)
    {
        if (num == 0)
        {
            ySpeed = 10f;
        }
        if (num == 1)
        {
            ySpeed = 7f;
        }
        if (num ==2)
        {
            ySpeed = 13;
        }
    }


}

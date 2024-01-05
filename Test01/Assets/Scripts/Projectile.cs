using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;



public class Projectile : MonoBehaviour
{

    Rigidbody2D rigid;
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    Vector3 playerPos;
    Vector3 direction;
    float angle;
    Pooler pooler;

    [SerializeField] bool isCol;

    public bool isAxe = true;
    public bool isSpike;
    public int demage;
    // Start is called before the first frame update
    void Start()
    {
        pooler = GetComponent<Pooler>();

        rigid = GetComponent<Rigidbody2D>();

        playerPos = PlayerLocation.Instance.PlayerPosition();

        Destroy(gameObject, 10f);

        float dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y - transform.position.y, 2));
        direction = new Vector2((playerPos.x - transform.position.x) / dev, (playerPos.y - transform.position.y) / dev);

       
        angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;

        if (isAxe)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
        if (isAxe == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        }

        if (isSpike)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle + 30f);
        }
    }

    public void SetDirection(Vector3 pos)
    {
        playerPos = PlayerLocation.Instance.PlayerPosition();

        //Destroy(gameObject, 10f);

        float dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - pos.x, 2) + Mathf.Pow(playerPos.y - pos.y, 2));
        direction = new Vector2((playerPos.x - pos.x) / dev, (playerPos.y - pos.y) / dev);


        angle = Mathf.Atan2(playerPos.y - pos.y, playerPos.x - pos.x) * Mathf.Rad2Deg;

        if (isAxe)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (isAxe == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        }

        if (isSpike)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle + 30f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += direction * Time.deltaTime * speed;
        if (isAxe)
        {
            transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            if (isCol == true)
            {
                Destroy(gameObject);
                //pooler.ReleaseObject();
            }
        }
    }
}

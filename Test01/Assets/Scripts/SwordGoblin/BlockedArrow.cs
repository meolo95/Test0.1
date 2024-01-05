using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedArrow : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float enemyX;
    public bool isDrop = false;
    [SerializeField] float rotateSpeed = 1000f;
    Vector2 power;
    public int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (isDrop == false)
        {
            rigid = GetComponent<Rigidbody2D>();
            if (enemyX - transform.position.x > 0)
            {
                power = new Vector2(-5f, 5f);
            }
            if (enemyX - transform.position.x <= 0)
            {
                power = new Vector2(5f, 5f);
            }
            rigid.AddForce(power, ForceMode2D.Impulse);
        }
        else if (isDrop == true)
        {
            rigid.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isDrop)
        {
            transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerLocation.Instance.UseArrow(num);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Platform")
        {
            isDrop = false;
        }
    }


}

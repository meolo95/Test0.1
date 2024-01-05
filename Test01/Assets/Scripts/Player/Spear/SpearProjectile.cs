using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearProjectile : MonoBehaviour
{
    Rigidbody2D rigid;
    float dir;
    [SerializeField] float speed;
    [SerializeField] GameObject usedSpear;

    // Start is called before the first frame update
    void Start()
    {
        dir = PlayerLocation.Instance.hodir();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = rigid.velocity;
        rigid.velocity = new Vector2(dir * speed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.tag == "HitZone")
        {
            Vector3 hitpos = transform.position;
            Instantiate(usedSpear, hitpos, transform.rotation);
            Destroy(gameObject);
        }

        if (otherObject.tag == "Platform")
        {
            Vector3 hitpos = transform.position;
            Instantiate(usedSpear, hitpos, transform.rotation);
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ArrowProjectile : MonoBehaviour
{

    Rigidbody2D rigid;
    Pooler pooler;
    AttackZone attackZone;
    [SerializeField] float speed;
    [SerializeField] GameObject usedArrow;
    [SerializeField] GameObject blockedArrow;
    Vector2 direction;
    float x;
    bool isFire = true;
    Vector3 instpos;

    // Start is called before the first frame update
    void Start()
    {
        attackZone = GetComponent<AttackZone>();
        pooler = GetComponent<Pooler>();
        rigid = GetComponent<Rigidbody2D>();
        x = Mathf.Sqrt(1 - Mathf.Pow(PlayerLocation.Instance.BowAngle(), 2));
        direction = new Vector2(x, PlayerLocation.Instance.BowAngle());
        PlayerLocation.Instance.DefaultAngle();
        instpos = transform.position;
        //rigid.AddForce(direction * speed, ForceMode2D.Impulse);
        //Destroy(gameObject, 2f);
        //rigid.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        //rigid.velocity = (Vector2.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = rigid.velocity;
        if (isFire)
        {
            direction.x = direction.x * PlayerLocation.Instance.hodir();

            rigid.AddForce(direction * speed, ForceMode2D.Impulse);
            PlayerLocation.Instance.DefaultAngle();
            isFire = false;
        }
        
    }

    public void SetDirection()
    {
        if (attackZone != null)
        {
            attackZone.isUsed = false;
        }
        x = Mathf.Sqrt(1 - Mathf.Pow(PlayerLocation.Instance.BowAngle(), 2));
        direction = new Vector2(x, PlayerLocation.Instance.BowAngle());
        PlayerLocation.Instance.DefaultAngle();
        instpos = transform.position;
        isFire = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.tag == "HitZone")
        {
            if (otherObject.GetComponent<Health>().Shielding == false && otherObject.GetComponent<Health>().isSmall == false)
            {
                attackZone.isUsed = false;
            }

            if (otherObject.GetComponent<Health>().Shielding == true)
            {
                Vector3 hitpos = transform.position;
                hitpos += transform.right * 0.2f;
                GameObject newArrows = Instantiate(blockedArrow, transform.position, transform.rotation);
                newArrows.GetComponent<BlockedArrow>().enemyX = hitpos.x;
                //pooler.ReleaseObject();
                attackZone.isUsed = false;
                Destroy(gameObject);
            }
            //Destroy(newArrows, 3f);


        }

        if (otherObject.tag == "Platform")
        {
            GameObject sharedParent = new GameObject("Father");
            //GameObject sharedParent = PoolManager.Instance.GetGo("HitPlace");
            sharedParent.transform.position = otherObject.transform.position;
            sharedParent.transform.rotation = otherObject.transform.rotation;
            sharedParent.transform.SetParent(otherObject.gameObject.transform);

            Vector3 hitpos = transform.position;
            hitpos += transform.right * 0.5f;

            GameObject newArrows = Instantiate(usedArrow, hitpos, transform.rotation);
            //GameObject newArrows = PoolManager.Instance.GetGo("UsedArrow");
            //newArrows.transform.position = hitpos;
            //newArrows.transform.rotation = transform.rotation;
            newArrows.transform.SetParent(sharedParent.transform, true);
            //pooler.ReleaseObject();
            Destroy(gameObject);


        }
    }
}

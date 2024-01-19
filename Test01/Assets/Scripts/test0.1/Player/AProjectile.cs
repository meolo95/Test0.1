using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AProjectile : MonoBehaviour
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

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        attackZone = GetComponent<AttackZone>();
        pooler = GetComponent<Pooler>();
        rigid = GetComponent<Rigidbody2D>();
        x = Mathf.Sqrt(1 - Mathf.Pow(angle, 2));
        direction = new Vector2(x, angle);
        PlayerLocation.Instance.DefaultAngle();
        instpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = rigid.velocity;
        if (isFire)
        {
            direction.x = direction.x * PlayerLocation.Instance.dir;

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

            GameObject sharedParent = new GameObject("Father");
            //GameObject sharedParent = PoolManager.Instance.GetGo("HitPlace");
            sharedParent.transform.position = otherObject.transform.position;
            sharedParent.transform.rotation = otherObject.transform.rotation;
            sharedParent.transform.SetParent(otherObject.gameObject.transform);

            Vector3 hitpos = transform.position;
            hitpos += transform.right * 0.5f;

            if (otherObject.GetComponentInParent<EnemyBehavior>() != null && otherObject.GetComponentInParent<EnemyBehavior>().isDevine == false)
            {
                GameObject newArrows = Instantiate(usedArrow, hitpos, transform.rotation);
                newArrows.transform.SetParent(sharedParent.transform, true);
            }
            else if (otherObject.GetComponentInParent<EnemyBehavior>() != null && otherObject.GetComponentInParent<EnemyBehavior>().isDevine == true)
            {
                GameObject newArrows = Instantiate(blockedArrow, hitpos, transform.rotation);
                //newArrows.transform.SetParent(sharedParent.transform, true);
            }
            else
            {
                GameObject newArrows = Instantiate(usedArrow, hitpos, transform.rotation);
                newArrows.transform.SetParent(sharedParent.transform, true);
            }

            //GameObject newArrows = PoolManager.Instance.GetGo("UsedArrow");
            //newArrows.transform.position = hitpos;
            //newArrows.transform.rotation = transform.rotation;

            //pooler.ReleaseObject();
            Destroy(gameObject);




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

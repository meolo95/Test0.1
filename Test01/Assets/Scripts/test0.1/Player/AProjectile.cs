using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AProjectile : MonoBehaviour
{
    Rigidbody2D rigid;
    Pooler pooler;
    AttackZone attackZone;
    [SerializeField] float speed;
    Vector2 direction;
    float x;
    bool isFire = true;
    Vector3 instpos;

    public float angle;

    // Start is called before the first frame update
    private void Awake()
    {
        attackZone = GetComponent<AttackZone>();
        pooler = GetComponent<Pooler>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        isFire = false;
        x = Mathf.Sqrt(1 - Mathf.Pow(angle, 2));
        direction = new Vector2(x, angle);
        direction.x = direction.x * PlayerManage.Instance.dir;
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);

        //instpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = rigid.velocity;
    }

}

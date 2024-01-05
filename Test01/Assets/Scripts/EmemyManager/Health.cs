using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{

    [SerializeField] GameObject obj;
    [SerializeField] public int demage;
    [SerializeField] GameObject usedArrow;
    [SerializeField] GameObject blockedArrow;
    Enemy enemy;

    [SerializeField] public GameObject body;
    
    
    // get set private
    //


    [SerializeField] public bool Shielding = false;
    [SerializeField] public bool isSmall;

    // Start is called before the first frame update
    private void Awake()
    {
        enemy = obj.GetComponent<Enemy>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DemageEnemy(int amount)
    {

        if (Shielding == false)
        {
            SoundManager.Instance.SFXHitPlay("Hit", transform.position, 0.5f, 10f);
            enemy.hited = true;
            enemy.demage = amount;

        }

        if (Shielding)
        {
            SoundManager.Instance.SFXHitPlay("Blocked", transform.position, 1f, 15f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(collision);
            if (Shielding == false)
            {
                GameObject sharedParent = new GameObject("Father");
                //GameObject sharedParent = PoolManager.Instance.GetGo("HitPlace");
                sharedParent.transform.position = body.transform.position;
                sharedParent.transform.rotation = body.transform.rotation;
                sharedParent.transform.SetParent(body.transform);

                Vector3 hitpos = transform.position;
                hitpos += transform.right * 0.2f;

                GameObject newArrows = Instantiate(usedArrow, hitpos, transform.rotation);
                //GameObject newArrows = PoolManager.Instance.GetGo("UsedArrow");
                //newArrows.transform.position = hitpos;
                //newArrows.transform.rotation = transform.rotation;
                newArrows.transform.SetParent(sharedParent.transform, true);
                newArrows.GetComponent<UsedArrow>().isEnemy = true;
                //Destroy(gameObject);
                //pooler.ReleaseObject();
            }


            if (Shielding)
            {
                Vector3 hitpos = transform.position;
                hitpos += transform.right * 0.2f;
                GameObject newArrows = Instantiate(blockedArrow, transform.position, transform.rotation);
                newArrows.GetComponent<BlockedArrow>().enemyX = hitpos.x;
            }
        }
    }


}

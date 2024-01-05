using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{

    [SerializeField] public int health;
    [SerializeField] GameObject obj;
    [SerializeField] public int demage;

    [SerializeField] public GameObject body;

    [SerializeField] public bool Shielding = false;
    [SerializeField] public bool isSmall;

    // Start is called before the first frame update
    void Start()
    {
        //enemy = GameObject.Find("Enemy");
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
            obj.GetComponent<Enemy>().HitByPlayer();
            health -= amount;
            if (health <= 0)
            {
                obj.GetComponent<Enemy>().DestroyEnemy();
            }
        }

        if (Shielding)
        {
            SoundManager.Instance.SFXHitPlay("Blocked", transform.position, 1f, 15f);
        }
    }


}

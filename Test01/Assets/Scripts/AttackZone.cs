using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private int demage;
    [SerializeField] private int reduceDemage;

    [SerializeField] public float weaponHp;

    [SerializeField] public float[] weaponBroken;

    [SerializeField] public float broke;

    [SerializeField] GameObject[] brokenWeaponSword;
    [SerializeField] GameObject[] brokenWeaponSpear;

    BoxCollider2D boxCollider2D;

    public bool isUsed = false;

    public Vector2 boxSize;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxSize = boxCollider2D.size;
        offset = boxCollider2D.offset;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.TryGetComponent<Health>(out Health )  
        if(collision.GetComponent<Health>() != null)
        {
            if (isUsed == false)
            {
                Health health = collision.GetComponent<Health>();
                health.DemageEnemy(demage);
                if (health.isSmall == false)
                {
                    isUsed = true;
                }
            }


            //weaponHp[PlayerLocation.Instance.GetWeaponNum()] -= 1;

            for (int i = 0; i < weaponBroken.Length; i++)
            {
                if (weaponHp < weaponBroken[i])
                {
                    boxSize.x -= broke;
                    offset.x -= broke* 0.5f ;
                    boxCollider2D.size = boxSize;
                    boxCollider2D.offset = offset;
                    demage -= 1;
                    weaponBroken[i] = -1;

                    weaponbroke(i+1);

                }
            }
        }
    }

    void weaponbroke(int brokeTime)
    {
        foreach (var weapon in brokenWeaponSword)
        {
            weapon.SetActive(false);
        }
        brokenWeaponSword[brokeTime].SetActive(true);
    }

}

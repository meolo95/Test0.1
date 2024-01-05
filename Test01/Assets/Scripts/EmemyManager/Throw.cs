using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] GameObject targetObject;

    [SerializeField] GameObject[] projec;
    TargeterMove targeterMove;
    int rand;
    Vector3 throwpos;
    [SerializeField] bool isPlant;

    [SerializeField] bool isLow;
    // Start is called before the first frame update
    void Start()
    {
        targeterMove = GetComponent<TargeterMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Starter;

    void coStarter()
    {
        Starter = WaitAttack();
        StartCoroutine(Starter);
    }

    void coStoper()
    {
        Starter = WaitAttack();
        StopCoroutine(Starter);
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(targetObject, throwpos + (Vector3.up * -1f), Quaternion.identity);
        //PoolManager.Instance.GetGo()
    }

    public void ThrowObject()
    {
        throwpos = targeterMove.transform.position;
        if (isPlant == false)
        {
            Instantiate(targetObject, throwpos, Quaternion.identity);
        }
        if (isPlant == true)
        {
            coStoper();
            coStarter();
        }
    }

    public void ThrowBall()
    {
        Vector3 throwpos = targeterMove.transform.position;
        if (isLow)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(targetObject, throwpos, Quaternion.identity);
                obj.GetComponent<ThrownObject>().num = i;
            }
        }

        if (isLow == false)
        {
            if (isPlant == false)
            {
                GameObject obj1 = Instantiate(projec[0], throwpos + (Vector3.up * 0.5f), Quaternion.identity);
                //GameObject obj1 = PoolManager.Instance.GetGo("FireProjectile");
                //obj1.transform.position = throwpos + (Vector3.up * 0.5f);
                obj1.GetComponent<Projectile>().isAxe = false;
                //obj1.GetComponent<Projectile>().SetDirection(obj1.transform.position);
            }
            if (isPlant)
            {
                GameObject obj1 = Instantiate(projec[0], throwpos + (Vector3.down * 1f), Quaternion.identity);
                //GameObject obj1 = PoolManager.Instance.GetGo("GreenBall");
                
                //obj1.transform.position = throwpos + (Vector3.down * 1f);
                obj1.GetComponent<Projectile>().isAxe = false;
                //obj1.GetComponent<Projectile>().SetDirection(obj1.transform.position);
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : EnemyManage, IAttack, IBreak
{
    [SerializeField] GameObject projectile;
    [SerializeField] string objName;
    [SerializeField] float delay;

    public void Attack()
    {
        
        if (IEThrow == null)
        {
            ThrowStart();
        }
        //Instantiate(projectile, new Vector2(0f, 0f), Quaternion.identity);
    }

    public void Break()
    {
        ThrowStop();
    }

    IEnumerator IEThrow;

    public EnemyThrow()
    {
    }

    void ThrowStart()
    {
        IEThrow = Throw();
        StartCoroutine(IEThrow);
    }
    void ThrowStop()
    {
        if (IEThrow != null)
        {
            StopCoroutine(IEThrow);
            IEThrow = null;
        }
    }

    IEnumerator Throw()
    {
        AnimSetTrue("IsReady");
        yield return new WaitForSeconds(delay);
        if (transform.position.x < PlayerManage.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerManage.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        AnimSetTrue("IsAttack");
        //Instantiate(projectile, transform.position, Quaternion.identity);
        ObjectPoolManager.Instance.Get(objName, transform.position, Quaternion.identity, 0f);
        yield return new WaitForSeconds(0.3f);
        IEThrow = null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour, IAttack, IBreak
{
    [SerializeField] GameObject projectile;
    [SerializeField] float delay;

    private void Update()
    {
        
    }

    public void Attack()
    {
        if (transform.position.x < PlayerLocation.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (transform.position.x > PlayerLocation.Instance.PlayerPosition().x)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
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
        yield return new WaitForSeconds(delay);
        Instantiate(projectile, transform.position, Quaternion.identity);
        IEThrow = null;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHideUp : EnemyManage, IEtc
{
    bool isUp;
    bool isCol;
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Etc()
    {
        if (isCol)
        {
            StartCool();
        }
    }

    IEnumerator IECool;
    void StartCool()
    {
        if (IECool == null)
        {
            IECool = Cool();
            StartCoroutine(IECool);
        }
    }
    IEnumerator Cool()
    {
        rigid.velocity = new Vector2(0f, 3f);
        Light1.SetActive(true);
        Light2.SetActive(true);
        yield return new WaitForSeconds(2f);
        rigid.velocity = Vector2.zero;
    }
}

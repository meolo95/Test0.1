using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DG.Tweening.DOTweenModuleUtils;

public class EnemyDrop : EnemyManage, IEtc
{
    GameObject dropper;
    protected override void Awake()
    {
        base.Awake();
        //dropper = GetComponentInParent<GameObject>();
        dropper = transform.parent.gameObject;
        transform.parent = null;
    }
    public void Etc()
    {
        transform.position = dropper.transform.position + Vector3.down * 0.5f;
        Vector3 scale = dropper.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}

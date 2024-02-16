using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReset : EnemyManage
{
    protected List<int> lists = new List<int>();
    protected void Ref(List<int> children)
    {
        foreach (var child in children)
        {
            ObjectPoolManager.Instance.ReleaseOnPull("UsedArrow", child);
            Debug.Log(child);
        }
    }
}

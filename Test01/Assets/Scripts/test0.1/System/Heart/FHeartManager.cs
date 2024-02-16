using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FHeartManager : HeartClass
{

    public override void UpdateHearts()
    {
        heartFill = PlayerManage.Instance.frozenHp;
        foreach (Image i in hearts)
        {
            i.fillAmount = heartFill * 0.5f;
            heartFill -= 2f;
        }
    }
}

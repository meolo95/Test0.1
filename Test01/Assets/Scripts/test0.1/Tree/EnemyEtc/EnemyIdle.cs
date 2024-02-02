using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyManage, IEtc
{
    public void Etc()
    {
        AnimSetTrue("IsIdle");
    }
}

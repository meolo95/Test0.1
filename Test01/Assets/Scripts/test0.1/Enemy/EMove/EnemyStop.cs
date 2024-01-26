using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : EnemyManage, IMove
{
    public void Move()
    {
        AnimSetTrue("IsIdle");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    arrow,
    bow,
    arrowhand
}

public abstract class PAttack
{
    public abstract void Attack(EnemyBehavior behavior);
}

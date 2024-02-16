using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BehaviorTree
{
    private readonly Node root;
    public BehaviorTree(Node root)
    {
        this.root = root;
    }

    public void Update()
    {
        root.Execute();
    }

}

public interface Node
{
    bool Execute();
}

public class Selector : Node
{
    private readonly Node[] nodes;

    public Selector(params Node[] nodes)
    {
        this.nodes = nodes;
    }

    public bool Execute()
    {
        foreach (var node in nodes)
        {
            if (node.Execute())
            {
                return true;
            }
        }
        return false;
    }
}

public class Sequence : Node
{
    private readonly Node[] nodes;

    public Sequence(params Node[] nodes)
    {
        this.nodes = nodes;
    }
    public bool Execute()
    {
        foreach (var node in nodes)
        {
            if (!node.Execute())
            {
                return false;
            }
        }
        return true;
    }
}

public class Paralle : Node
{
    private readonly Node[] nodes;
    public Paralle(params Node[] nodes)
    {
        this.nodes = nodes;
    }

    public bool Execute()
    {
        foreach (var node in nodes)
        {
            node.Execute();
        }
        return true;
    }
}

public class AttackBehavior : Node
{
    private IAttack attack;
    public AttackBehavior(IAttack attack)
    {
        this.attack = attack;
    }

    public bool Execute()
    {
        attack.Attack();
        return true;
    }
}

public class BreakBehavior : Node
{
    private IBreak breakBehavior;
    public BreakBehavior(IBreak breakBehavior)
    {
        this.breakBehavior = breakBehavior;
    }

    public bool Execute()
    {
        breakBehavior.Break();
        return true;
    }
}

public class MoveBehavior : Node
{
    private IMove move;
    public MoveBehavior(IMove move)
    {
        this.move = move;
    }

    public bool Execute()
    {
        move.Move();
        return true;
    }
}


public class EtcBehavior : Node
{
    private IEtc etc;
    public EtcBehavior(IEtc etc)
    {
        this.etc = etc;
    }

    public bool Execute()
    {
        etc.Etc();
        return true;
    }
}

public class PlayerDetection : Node
{
    private Collider2D collider;
    public PlayerDetection(Collider2D collider)
    {
        this.collider = collider;
    }

    public bool Execute()
    {
        float radius = Mathf.Max(collider.bounds.extents.x, collider.bounds.extents.y);
        Collider2D [] colliders = Physics2D.OverlapCircleAll(collider.bounds.center, radius, LayerMask.GetMask("Player"));
        if (colliders.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class HitBehavior : Node
{
    private IHit hit;
    public HitBehavior(IHit hit)
    {
        this.hit = hit;
    }
    public bool Execute() 
    {
        hit.Hit();
        return true;
    }
}
public class DieBehavior : Node
{
    private IDie die;
    public DieBehavior(IDie die)
    {
        this.die = die;
    }
    public bool Execute()
    {
        //die.Die();
        return true;
    }
}

public class HitDetection : MonoBehaviour, Node
{
    private GameObject root;
    private Collider2D col2D;
    private CoolDown cool;
    private HPManage hpCheck;


    public HitDetection(GameObject root, Collider2D colliders, CoolDown cool, HPManage hpCheck)
    {
        this.root = root;
        this.col2D = colliders;
        this.cool = cool;
        this.hpCheck = hpCheck;
    }
    public bool Execute()
    {
        float radius = Mathf.Max(col2D.bounds.extents.x, col2D.bounds.extents.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(col2D.bounds.center, radius);
        
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.TryGetComponent<AttackZone>(out AttackZone attackZone))
            {
                if (attackZone.isUsed == false)
                {
                    hpCheck.SetHP(attackZone.demage);
                    attackZone.isUsed = true;

                    cool.SetTimer(true);

                    if (attackZone.usedArrow != null)
                    {
                        GameObject sharedParent = new GameObject("Father");
                        sharedParent.transform.position = col.gameObject.transform.position;
                        sharedParent.transform.rotation = col.gameObject.transform.rotation;
                        sharedParent.transform.SetParent(root.gameObject.gameObject.transform);
                        Vector3 hitpos = col.transform.position;
                        hitpos += col.transform.right * 0.2f;
                        GameObject newArrows = Instantiate(attackZone.usedArrow, hitpos, col.transform.rotation);
                        newArrows.transform.SetParent(sharedParent.transform, true);
                        Destroy(col.gameObject);
                    }
                    return true;
                }
            }
        }
        return false;
    }
}

public class CoolDown : Node
{
    bool isCool;
    private float time;
    private float timer;
    public CoolDown(float time)
    {
        isCool = false;
        this.time = time;
        timer = 0f;
    }

    public void SetTimer(bool isCool)
    {
        this.isCool = isCool;
        if (isCool)
        {
            timer = 0f;
        }
    }

    public bool Execute()
    {
        if (isCool)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                isCool = false;
                timer = 0f;
                return true;
            }
            return false;
        }
        else
        {
            return true;
        }
    }
}

public class HPManage : Node
{
    private int hp;
    public HPManage(int hp)
    {
        this.hp = hp;
    }

    public void SetHP(int hp)
    {
        this.hp -= hp;
    }

    public bool Execute()
    {
        if (hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree
{
    //모던 C++ 디자인 패턴
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

public class Tree : MonoBehaviour
{
    private BehaviorTree tree;
    Node node;

    private void Awake()
    {
        //node = GetComponent<EnemyRoaming>();
    }

    private void Start()
    {
        tree = new BehaviorTree(
            new Selector(
                new Sequence(
                    new MoveBehavior()), 
                new Sequence(
                    new AttackBehavior()), 
                new Sequence(
                    new EtcBehavior())
                ));
    }

    private void Update()
    {
        tree.Update();
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

public class AttackBehavior : MonoBehaviour, Node
{
    private IAttack attack;
    private void Awake()
    {
        attack = GetComponent<IAttack>();
    }

    public bool Execute()
    {
        attack.Attack();
        return true;
    }
}

public class MoveBehavior : MonoBehaviour, Node
{
    private IMove move;
    private void Awake()
    {
        move = GetComponent<IMove>();
    }
    public bool Execute()
    {
        move.Move();
        return true;
    }
}

public class EtcBehavior : MonoBehaviour, Node
{
    private IEtc etc;
    private void Awake()
    {
        etc = GetComponent<IEtc>();
    }
    public bool Execute()
    {
        etc.Etc();
        return true;
    }
}



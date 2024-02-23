using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public GameObject root;

    public BehaviorTree tree;

    private IMove move;
    private IAttack attack;
    private IBreak breakbehavior;
    private IEtc etc;
    private IHit hit;
    private IDie die;
    private IFind find;
    private IHDetect hDetect;

    Collider2D targetCollider;
    Collider2D hitCollider;
    CoolDown cool;
    HPManage hpCheck;

    [SerializeField] int hp;

    private void Awake()
    {
        root = gameObject;
        move = GetComponent<IMove>();
        attack = GetComponent<IAttack>();
        breakbehavior = GetComponent<IBreak>();
        etc = GetComponent<IEtc>();
        hit = GetComponent<IHit>();
        die = GetComponent<IDie>();
        find = GetComponent<IFind>();
        hDetect = GetComponentInChildren<IHDetect>();
        //targetCollider = transform.GetChild(1).GetComponent<Collider2D>();
        hitCollider = transform.GetChild(0).GetComponent<Collider2D>();
        cool = new CoolDown(1.5f);
        hpCheck = new HPManage(hp);
    }

    private void Start()
    {
        tree = new BehaviorTree(
            new Selector(
                new Sequence(hpCheck, new BreakBehavior(breakbehavior), new DieBehavior(die)
                    ),
                new Paralle(
                    new Sequence(
                        new HitDetection(root, hitCollider, cool, hpCheck), new HitBehavior(hit)
                        ),
                    new Selector(
                        new Sequence(
                            new DetectNode(find), new AttackBehavior(attack)
                            ),
                        new Sequence(
                            new BreakBehavior(breakbehavior), new MoveBehavior(move)
                            ),
                        new Sequence(
                            new EtcBehavior(etc)
                            )))
                ));
    }

    private void Update()
    {
        tree.Update();
    }
}

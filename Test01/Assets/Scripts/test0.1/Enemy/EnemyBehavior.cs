using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyBehavior : MonoBehaviour
{
    
    public List<int> children = new List<int>();


    protected EnemyManage enemy;
    private IAttack attackBehavior;
    private IMove moveBehavior;
    public IHit hitBehavior;
    private IDie dieBehavior;
    private IEtc etc;
    private IBreak attackBreak;
    private IMBreak moveBreak;

    Animator anim;

    [SerializeField] int health;

    Rigidbody2D rigid;
    
    //UNIT - PLAYER, ENEMY, - HIT MOVE (INTERFACE) -���¹��� ��巹���� ����-
    // ������Ʈ Ǯ, ���� ������Ʈ Ǯ, trygetcomponent

    public EnemyState state = EnemyState.moving;
    public EnemyLife life = EnemyLife.living;
    public EnemyHitState hitState = EnemyHitState.idle;

    public bool check;
    public bool isDevine;

    

    private void Awake()
    {
        attackBehavior = GetComponent<IAttack>();
        moveBehavior = GetComponent<IMove>();
        hitBehavior = GetComponent<IHit>();
        dieBehavior = GetComponent<IDie>();
        etc = GetComponent<IEtc>();
        attackBreak = GetComponent<IBreak>();
        moveBreak = GetComponent<IMBreak>();

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Living();
    }

    void Behavior()
    {
        switch (state)
        {
            case EnemyState.moving:
                if (moveBehavior != null)
                {
                    if (hitState == EnemyHitState.idle)
                    {
                        moveBehavior.Move();
                    }
                }
                if (attackBreak != null)
                {
                    attackBreak.Break();
                }
                break;
            case EnemyState.targeting:
                if (attackBehavior != null)
                {
                    attackBehavior.Attack();
                }
                break;
            case EnemyState.Etc:
                if (etc != null)
                {
                    etc.Etc();
                }
                break;
        }
    }

    void Living()
    {
        HitBehavior();
        switch (life)
        {
            case EnemyLife.living:
                Behavior();
                
                break;
            case EnemyLife.dying:
                if (dieBehavior != null)
                {
                    if (attackBreak != null)
                    {
                        attackBreak.Break();
                    }
                    if (moveBreak != null)
                    {
                        moveBreak.MBreak();
                    }
                    dieBehavior.Die(children);

                }
                break;
        }
    }
    
    void HitBehavior()
    {
        switch(hitState)
        {
            case EnemyHitState.idle:
                break;
            case EnemyHitState.hitting:
                if (moveBreak != null)
                {
                    moveBreak.MBreak();
                }
                if (check == false)
                {
                    if (hitBehavior != null)
                    {
                        hitBehavior.Hit();
                    }
                    //EnemyManage(-1, 0, 0, 0);
                    check = true;
                }
                break;
        }
    }

    

    public void EnemyManage(int h)
    {
        health += h;

        if (health <= 0)
        {
            life = EnemyLife.dying;
        }
    }


    
}

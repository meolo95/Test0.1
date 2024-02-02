using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyBehavior : MonoBehaviour
{
    protected EnemyManage enemy;
    private IAttack attackBehavior;
    private IMove moveBehavior;
    public IHit hitBehavior;
    private IDie dieBehavior;
    private IEtc etc;
    private IBreak attackBreak;

    Animator anim;

    [SerializeField] int health;

    Rigidbody2D rigid;
    
    //UNIT - PLAYER, ENEMY, - HIT MOVE (INTERFACE) -에셋번들 어드레서블 에셋-
    // 오브젝트 풀, 사운드 오브젝트 풀, trygetcomponent

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
        switch (life)
        {
            case EnemyLife.living:
                Behavior();
                HitBehavior();
                break;
            case EnemyLife.dying: 
                if (dieBehavior != null)
                {
                    dieBehavior.Die();
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


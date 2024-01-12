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

    Animator anim;

    [SerializeField] string enemyname;
    [SerializeField] int health;
    [SerializeField] int demage;
    [SerializeField] int stun;
    [SerializeField] int speed;

    Rigidbody2D rigid;
    

    public EnemyState state;
    public EnemyLife life;
    public EnemyHitState hitState;

    public bool check;
    public bool isDevine;

    

    private void Awake()
    {
        attackBehavior = GetComponent<IAttack>();
        moveBehavior = GetComponent<IMove>();
        hitBehavior = GetComponent<IHit>();
        dieBehavior = GetComponent<IDie>();
        etc = GetComponent<IEtc>();

        enemy = new EnemyManage(enemyname, health, demage, stun, speed);

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        state = EnemyState.moving;
        life = EnemyLife.living;
        hitState = EnemyHitState.idle;
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
                    hitBehavior.Hit();
                    EnemyManage(-1, 0, 0, 0);
                    check = true;
                }
                break;
        }
    }

    

    public void EnemyManage(int h, int d, int s, int sp)
    {
        enemy.health += h;
        enemy.demage += d;
        enemy.stun += s;
        enemy.speed += sp;

        if (enemy.health <= 0)
        {
            life = EnemyLife.dying;
        }
    }

}


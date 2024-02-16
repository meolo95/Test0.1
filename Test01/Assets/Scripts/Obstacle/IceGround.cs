using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGround : MonoBehaviour
{
    public static IceGround Instance = null;

    [SerializeField] float limit;

    FrozenCamera FC;
    float timer = 0f;

    public bool isIce = true;

    bool check;

    int iceLv;

    public bool demaging;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        FC = GetComponent<FrozenCamera>();
        StartCoroutine(BeIce());
    }

    // Update is called once per frame
    void Update()
    {
        if (isIce)
        {
            timer += Time.deltaTime;
        }
        if (timer > limit)
        {
            check = true;
            demaging = true;
            timer = 0f;
        }
        if (isIce != true)
        {
            timer = 0f;
            PlayerManage.Instance.frozenHp = 0;
        }

        if (check)
        {
            StartCo();
        }

        if (timer < 4 && demaging == false)
        {
            iceLv = 0;
        }
        if (timer > 4 && timer < 8)
        {
            iceLv = 1;
        }
        if (timer > 8 && timer < 12)
        {
            iceLv = 2;
        }
        if (timer > 12 && timer < 16)
        {
            iceLv = 3;
        }
        if (timer > 16)
        {
            iceLv = 4;
        }

        switch (iceLv)
        {
            case 0:
                FC.size = 1.5f;
                break;
            case 1:
                FC.size = 0.9f;
                break;
            case 2:
                FC.size = 0.75f;
                break;
            case 3:
                FC.size = 0.45f;
                break;
            case 4:
                FC.size = 0.1f;
                break;

            default:
                break;
        }
    }

    IEnumerator BeIce()
    {
        yield return new WaitForSeconds(0.2f);
        //isIce = true;
        //(BeIce());
    }

    IEnumerator TickDemage()
    {
        check = false;
        if (demaging)
        {
            PlayerManage.Instance.frozenHp++;
        }
        yield return new WaitForSeconds(2f);
        timer = 0f;
        if (demaging)
        {
            StartCo();
        }
    }

    IEnumerator DemageCo;

    public void StartCo()
    {
        DemageCo = TickDemage();
        StartCoroutine(TickDemage());
    }
    public void StopCo()
    {
        DemageCo = TickDemage();
        StopCoroutine(TickDemage());
    }

}

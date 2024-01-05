using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeakGround : MonoBehaviour
{
    [SerializeField] float limit;
    [SerializeField] float repairTime;

    [SerializeField] SpriteRenderer SR;


    BoxCollider2D box2D;
    public float timer;
    public bool check;
    public bool isIn;
    float invisible;

    // Start is called before the first frame update
    void Start()
    {
        box2D = GetComponent<BoxCollider2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn)
        {
            timer += Time.deltaTime;
        }
        if (limit < timer)
        {
            StartCoroutine(cool());
        }
        if (check == false)
        {
            Invisible();
        }
    }


    void Invisible()
    {
        if (isIn && timer > limit - 1f)
        {
            invisible = limit - timer;
            SR.color = new Color(1f, 1f, 1f, invisible);
        }
    }

    IEnumerator cool()
    {
        //SR.color = new Color(1f, 1f, 1f, 0f);
        check = true;
        box2D.enabled = false;
        timer = 0f;
        yield return new WaitForSeconds(repairTime);
        box2D.enabled = true;
        SR.color = new Color(1f, 1f, 1f, 1f);
        check = false;
    }

    IEnumerator CoRe;

    public void StartCo()
    {
        CoRe = repair();
        StartCoroutine(CoRe);
    }

    public void StopCo()
    {
        CoRe = repair();
        StopCoroutine(CoRe);
    }

    IEnumerator repair()
    {
        if (check == false)
        {
            yield return new WaitForSeconds(1f);
            if (isIn == false)
            {
                timer = 0f;
                SR.color = new Color(1f, 1f, 1f, 1f);
            }
        }
        else
        {
            yield return null;
        }
    }
}

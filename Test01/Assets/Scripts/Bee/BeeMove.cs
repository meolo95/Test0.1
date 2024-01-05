using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    Bee bee;
    [SerializeField] public float speed;
    public float delay;
    float dev;
    float timer = 0f;
    Vector2 pos;
    Enemy enemy;

    public bool isTargeting;
    // Start is called before the first frame update
    void Start()
    {
        bee = GetComponent<Bee>();
        enemy= GetComponent<Enemy>();
        //StartCoroutine(MoveDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (isTargeting == true)
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                Debug.Log(timer);
                timer = 0f;
                StartCoroutine(MoveDelay());
            }
        }
        else
        {
            timer = 0f;
        }

        if (enemy.isHit)
        {
            StopCoroutine(MoveDelay());
            bee.rigid.velocity = Vector3.zero;
        }
    }



    public IEnumerator MoveDelay()
    {
        isTargeting = false;
        bee.beeAnim.SetBool("IsAttack", true);
        bee.beeAnim.SetBool("IsTarget", false);
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition();

        if (playerPos.x > transform.position.x)
        {
            bee.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            bee.transform.localScale = new Vector3(-1, 1, 1);
        }

        bee.rigid.velocity = new Vector2(pos.x * speed, pos.y * speed);
        yield return new WaitForSeconds(dev * 0.15f);
        bee.rigid.velocity = Vector2.zero;
        timer = 0f;
        bee.beeAnim.SetBool("IsAttack", false);
        bee.beeAnim.SetBool("IsTarget", true);
    }

    public void GetTarget()
    {
        Vector3 playerPos = PlayerLocation.Instance.PlayerPosition();
        dev = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2) + Mathf.Pow(playerPos.y  - transform.position.y, 2));
        pos = new Vector2((playerPos.x - transform.position.x)/dev, (playerPos.y - transform.position.y)/dev);
    }


}

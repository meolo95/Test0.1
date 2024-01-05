using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    Vector3 pos;
    Vector3 downPos;
    [SerializeField] float speed;
    [SerializeField] float upSpeed;
    [SerializeField] float distance;
    [SerializeField] bool isReverse;

    bool down;
    bool up;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        downPos = pos;
        if (!isReverse)
        {
            downPos.y -= distance;
        }
        if (isReverse)
        {
            downPos.y += distance;
        }
        StartCoroutine(Down());
    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            transform.position = Vector3.MoveTowards(transform.position, downPos, Time.deltaTime * speed);
        }
        if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * upSpeed);
        }
    }

    IEnumerator Down()
    {
        down = true;
        yield return new WaitForSeconds(1);
        down = false;
        yield return new WaitForSeconds(1);
        up = true;
        yield return new WaitForSeconds(1);
        up = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(Down());
    }

}

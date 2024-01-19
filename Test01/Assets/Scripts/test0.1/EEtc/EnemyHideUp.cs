using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHideUp : MonoBehaviour, IEtc
{
    bool isUp;
    bool isCol;
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;

    public void Etc()
    {
        if (isCol && isUp)
        {
            GetUp();
        }
    }

    void Ray()
    {
        Vector3 right = transform.position - new Vector3(0.5f, 0f);
        Vector3 left = transform.position - new Vector3(-0.5f, 10f);
        Collider2D col = Physics2D.OverlapArea(right, left, LayerMask.GetMask("Player"));
        if (col != null)
        {
            isCol = true;
        }
    }

    public void GetUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (4.5f * Vector3.up), Time.deltaTime * 12f);
        Light1.SetActive(true);
        Light2.SetActive(true);
    }

    IEnumerator Cool()
    {
        yield return new WaitForSeconds(2f);
        isUp = true;
    }
}

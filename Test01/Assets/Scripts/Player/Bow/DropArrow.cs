using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManage.Instance.arrow++;
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rigid;

    public PlayerCommand command;
    public PlayerLife life;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void Behavioir()
    {
    }

}

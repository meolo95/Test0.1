using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator beeAnim;
    public Rigidbody2D rigid;
    public SpriteRenderer spriterenderer;
    public bool isHit = false;
    void Start()
    {
        beeAnim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    //Enemy enemy;
    [SerializeField] public float stun;
    [SerializeField] public float devineTime;
    [SerializeField] Sprite[] sprite;

    Walking walking;
    public bool ishit;
    public bool isAlive = true;
    public bool isAttack = false;
    public bool isJumping;
    public bool isDevine;
    public bool isRoll = false;
    //public bool isSword = false;
    public bool isSpear = false;
    public float hordir;
    public int arrowNum = 20;


    

    // Start is called before the first frame update

    
    void Start()
    {
        //enemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        walking = GetComponent<Walking>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(enemy.stun);
        //rigid.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.F))
        {
            walking.anim.SetBool("IsSword", true);
        }

        if (transform.localScale == new Vector3(1f, 1f, 1f))
        {
            hordir = 1f;
        }
        else if (transform.localScale == new Vector3(-1f, 1f, 1f))
        {
            hordir = -1f;
        }

    }

    public void DestroyPlayer()
    {
        KeyManager.Instance.optionManager.isMain = true;
        isAlive = false;
        walking.anim.SetBool("IsDie", true);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        walking.anim.SetBool("IsDie", false);
        walking.anim.SetBool("IsAttack", false);
        walking.anim.SetBool("IsAttackArrow", false);
        walking.anim.SetBool("IsIdle", true);
        KeyManager.Instance.optionManager.isMain = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
        KeyManager.Instance.optionManager.SetOverPanel();
    }

    public void SetNormal()
    {
        walking.anim.SetBool("IsDie", false);
        walking.anim.SetBool("IsAttack", false);
        walking.anim.SetBool("IsAttackArrow", false);
        walking.anim.SetBool("IsIdle", true);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //isJumping = false;
            //walking.anim.SetBool("IsJumping", false);
            //Debug.Log(isJumping);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //isJumping = false;
        }

    }

}

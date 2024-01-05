using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BowAttack : MonoBehaviour
{
    Walking walking;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject aimingZone;
    Camera cam = null;

    public float angle = -0.5f;
    public bool isRight;
    public float hordir = 1f;

    bool isOver;
    bool isUnder;

    public AudioClip[] clips;

    bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        walking = GetComponent<Walking>();
        PlayerLocation.Instance.DefaultAngle();
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyManager.Instance.isMouse == true)
        {
            BowReady();
        }
        if (KeyManager.Instance.isKey == true)
        {
            BowKeyReady();
        }
    }

    void BowReady()
    {
        if (PlayerLocation.Instance.GetArrowNum() != 0 && Time.timeScale != 0f)
        {
            if (Input.GetMouseButton(0))
            {
                PlayerLocation.Instance.bowing = true;
                PlayerLocation.Instance.doingSomething = true;
                aimingZone.gameObject.SetActive(true);
                //walking.anim.SetBool("IsAttack", false);
                walking.anim.SetBool("IsReady", true);

                if (angle < PlayerLocation.Instance.BowLockOn().y)
                {
                    angle += Time.deltaTime * 0.9f;
                }
                if (PlayerLocation.Instance.BowLockOn().y < angle)
                {
                    angle -= Time.deltaTime * 0.9f;
                }
                if (LockOn().x > 0f)
                {
                    PlayerLocation.Instance.SetDirection(true);
                }
                if (LockOn().x < 0f)
                {
                    PlayerLocation.Instance.SetDirection(false);
                }

            }


            if (Input.GetMouseButtonUp(0))
            {
                aimingZone.gameObject.SetActive(false);
                walking.anim.SetBool("IsReady", false);
                //walking.anim.SetBool("IsAttack", true);
                if (angle > 1f)
                {
                    angle = 0.99f;
                }
                Debug.Log(angle);
                ArrowFire();
                PlayerLocation.Instance.UseArrow(-1);
                aimingZone.gameObject.SetActive(false);
                PlayerLocation.Instance.doingSomething = false;
                isOver = false;
                isUnder = false;
                PlayerLocation.Instance.bowing = false;

            }
        }

    }

    void BowKeyReady()
    {
        if (PlayerLocation.Instance.GetArrowNum() != 0 && Time.timeScale != 0f)
        {
            if (Input.GetKey(KeySetting.keys[KeyAction.Shoot]))
            {
                
                PlayerLocation.Instance.doingSomething = true;
                aimingZone.gameObject.SetActive(true);
                //walking.anim.SetBool("IsAttack", false);
                walking.anim.SetBool("IsReady", true);
                if (isShot == true)
                {
                    SoundManager.Instance.SFXDrawPlay("Draw", clips[0], 0.5f);
                    isShot = false;
                }
                if (angle > 1f)
                {
                    isOver = true;
                    isUnder = false;
                }
                if (angle <= -0.5f)
                {
                    isOver = false;
                    isUnder = true;
                }
                if (isUnder)
                {
                    angle += Time.deltaTime;
                }
                if (isOver)
                {
                    angle -= Time.deltaTime;
                }


            }


            if (Input.GetKeyUp(KeySetting.keys[KeyAction.Shoot]))
            {
                aimingZone.gameObject.SetActive(false);
                walking.anim.SetBool("IsReady", false);
                SoundManager.Instance.SFXPlay("Release", clips[1], 0.5f);
                SoundManager.Instance.StopPlay();
                //walking.anim.SetBool("IsAttack", true);
                if (angle > 1f)
                {
                    angle = 0.99f;
                }
                ArrowFire();
                PlayerLocation.Instance.UseArrow(-1);
                aimingZone.gameObject.SetActive(false);
                PlayerLocation.Instance.doingSomething = false;
                isOver = false;
                isUnder = false;
                isShot = true;

            }
        }


    }


    public Vector2 LockOn()
    {
        cam = Camera.main;
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        return direction;
    }

    void ArrowFire()
    {
        Vector3 pos = transform.position;
        pos.x += PlayerLocation.Instance.hodir() * 0.2f;
        Instantiate(arrow, transform.position, Quaternion.identity);
        //GameObject arrow = PoolManager.Instance.GetGo("Arrow");
        //arrow.transform.position = this.transform.position;
        //arrow.GetComponent<ArrowProjectile>().SetDirection();
    }
}

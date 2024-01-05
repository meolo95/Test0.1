using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLine : MonoBehaviour
{
    public static PlayerLine Instance = null;

    public LineRenderer line;
    public GameObject hook;
    Vector3 plocation;
    Vector3 posRight;
    Vector3 posLeft;
    bool isLineMax;
    Vector3 mouseDir;
    [SerializeField] float speed;

    [SerializeField] AudioClip clip;
    bool isUsing;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.transform.position);
        line.useWorldSpace = true;

        hook.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.transform.position);

        if (isUsing == false)
        {
            hook.transform.position = PlayerLocation.Instance.PlayerPosition();

        }
        GetPosition();

    }

    void GetPosition()
    {
        if (Input.GetKeyDown(KeySetting.keys[KeyAction.Hook]))
        {
            SoundManager.Instance.SFXPlay("Hook", clip, 1f);
            isUsing = true;
            hook.transform.position = PlayerLocation.Instance.PlayerPosition();
            plocation = PlayerLocation.Instance.PlayerPosition();
            posRight = PlayerLocation.Instance.PlayerPosition() + new Vector3(5f, 3f, 0f);
            posLeft = PlayerLocation.Instance.PlayerPosition() + new Vector3(-5f, 3f, 0f);
            PlayerLocation.Instance.hooking = true;
            hook.SetActive(true);
            
        }
        if (Input.GetKey(KeySetting.keys[KeyAction.Hook]) && isLineMax == false)
        {
            if (hook.GetComponent<HookControl>().isCol == false)
            {
                if (PlayerLocation.Instance.hodir() == 1)
                {
                    //hook.transform.position = posRight;
                    //hook.transform.Translate((posRight - plocation).normalized * 0.15f);
                    //hook.transform.position += (posRight - plocation).normalized * Time.deltaTime;

                    Vector3 dir = (posRight - plocation).normalized;
                    hook.GetComponent<HookControl>().rigid.velocity = dir * speed;
                }
                if (PlayerLocation.Instance.hodir() == -1)
                {
                    //hook.transform.position = posLeft;
                    //hook.transform.Translate((posLeft - plocation).normalized * 0.15f);
                    //hook.transform.position += (posLeft - plocation).normalized * Time.deltaTime;

                    Vector3 dir = (posLeft - plocation).normalized;
                    hook.GetComponent<HookControl>().rigid.velocity = dir * speed;
                }

                // hook.transform.Translate(mouseDir.normalized * Time.deltaTime * 15);
                if (Vector2.Distance(plocation, hook.transform.position) > 10)
                {
                    hook.transform.position = PlayerLocation.Instance.PlayerPosition();
                    hook.SetActive(false);
                    PlayerLocation.Instance.hooking = false;
                    isLineMax = true;
                    hook.GetComponent<HookControl>().rigid.velocity = Vector3.zero;
                }
            }

            else if (hook.GetComponent<HookControl>().isCol == true)
            {
                hook.GetComponent<HookControl>().joint.enabled = true;
                hook.GetComponent<HookControl>().rigid.velocity = Vector3.zero;
            }
            
            

        }
        
        if (Input.GetKeyUp(KeySetting.keys[KeyAction.Hook]))
        {
            hook.GetComponent<HookControl>().joint.enabled = true;
            hook.GetComponent<HookControl>().joint.enabled = false;
            hook.transform.position = PlayerLocation.Instance.PlayerPosition();
            isUsing = false;
            hook.GetComponent<HookControl>().isCol = false;
            isLineMax = false;
            PlayerLocation.Instance.hooking = false;
            hook.SetActive(false);
        }
    }

    public void TurnOff()
    {
        hook.GetComponent<HookControl>().joint.enabled = false;
        hook.transform.position = PlayerLocation.Instance.PlayerPosition();
        isUsing = false;
        hook.GetComponent<HookControl>().isCol = false;
        isLineMax = false;
        PlayerLocation.Instance.hooking = false;
        hook.SetActive(false);
    }
}

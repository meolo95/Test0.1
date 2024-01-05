using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    [SerializeField] public RuntimeAnimatorController anim1;
    [SerializeField] public RuntimeAnimatorController anim2;
    [SerializeField] public RuntimeAnimatorController anim3;
    [SerializeField] public RuntimeAnimatorController anim4;

    [SerializeField] float spearDelay;
    [SerializeField] float spearAttackTime;
    [SerializeField] float swordDelay;
    [SerializeField] float swordAttackTime;

    public GameObject[] parts;

    public Animator animator;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        player.GetComponent<PlayerAttack>().enabled = false;

        animator.runtimeAnimatorController = anim3;
        PlayerLocation.Instance.UseArrow(10);
        player.GetComponent<BowAttack>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<SpearThrow>().enabled = false;
        PlayerLocation.Instance.SetWeapon(2, swordDelay, swordAttackTime);

        foreach (var part in parts)
        {
            part.SetActive(false);
        }
        parts[2].SetActive(true);
        parts[4].SetActive(true);
        parts[5].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //ChangeAnimation();
    }

    public void ChangeAnimation()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //animator.runtimeAnimatorController = anim1;
            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<BowAttack>().enabled = false;
            player.GetComponent<SpearThrow>().enabled = false;

            foreach (var part in parts)
            {
                part.SetActive(false);
            }
            parts[0].SetActive(true);
        }
        if (Input.GetKey(KeyCode.G)) 
        {
            animator.runtimeAnimatorController = anim2;
            player.GetComponent<PlayerAttack>().enabled = true;
            player.GetComponent<BowAttack>().enabled = false;
            //player.GetComponent<Player>().isSword = true;
            player.GetComponent<Player>().isSpear = false;
            player.GetComponent<SpearThrow>().enabled = false;
            PlayerLocation.Instance.SetWeapon(0, swordDelay, swordAttackTime);

            foreach (var part in parts)
            {
                part.SetActive(false);
            }
            parts[1].SetActive(true);


        }

        if (Input.GetKey(KeyCode.H))
        {
            animator.runtimeAnimatorController = anim3;
            PlayerLocation.Instance.UseArrow(10);
            player.GetComponent<BowAttack>().enabled = true;
            player.GetComponent<PlayerAttack>().enabled = true;
            player.GetComponent<SpearThrow>().enabled = false;
            PlayerLocation.Instance.SetWeapon(2, swordDelay, swordAttackTime);

            foreach (var part in parts)
            {
                part.SetActive(false);
            }
            parts[2].SetActive(true);
            parts[4].SetActive(true);
            parts[5].SetActive(true);

        }

        if (Input.GetKey(KeyCode.J)) 
        {
            animator.runtimeAnimatorController = anim4;
            player.GetComponent <PlayerAttack>().enabled = true;
            player.GetComponent<BowAttack>().enabled = false;
            //player.GetComponent<Player>().isSword = false;
            player.GetComponent<Player>().isSpear = true;
            player.GetComponent<SpearThrow>().enabled = true;
            PlayerLocation.Instance.SetWeapon(1, spearDelay, spearAttackTime);

            foreach (var part in parts)
            {
                part.SetActive(false);
            }
            parts[3].SetActive(true);


        }
    }

    public void GoToHand()
    {
        animator.runtimeAnimatorController = anim1;
        player.GetComponent<PlayerAttack>().enabled = false;
        player.GetComponent<BowAttack>().enabled = false;
        player.GetComponent<SpearThrow>().enabled = false;
        //player.GetComponent<Player>().isSword = false;
        player.GetComponent<Player>().isSpear = false;

    }

    public void GoToSpear()
    {
        animator.runtimeAnimatorController = anim4;
        player.GetComponent<PlayerAttack>().enabled = true;
        player.GetComponent<BowAttack>().enabled = false;
        //player.GetComponent<Player>().isSword = false;
        player.GetComponent<Player>().isSpear = true;
        player.GetComponent<SpearThrow>().enabled = true;
        PlayerLocation.Instance.SetWeapon(1, spearDelay, spearAttackTime);
    }

    public void ArrowZero()
    {
        parts[6].SetActive(true);
        parts[4].SetActive(false);
    }

    public void ArrowFull()
    {
        parts[6].SetActive(false);
        parts[4].SetActive(true);
    }
}

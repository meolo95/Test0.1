using System.Collections;
using UnityEngine;

public class PlayerJump : PlayerBehaviour, IJump
{
    [SerializeField] float jumpSpeed;

    Vector2 size;
    Vector2 offset;
    protected override void Awake()
    {
        base.Awake();
        size = GetComponent<BoxCollider2D>().size;
        offset = GetComponent<BoxCollider2D>().offset;
    }
    public void Jump()
    {
        JumpCheck();
        if (PState.states[PlayerState.jump] == true)
        {
            if (Input.GetKeyDown(KeySetting.keys[KeyAction.Jump]))
            {
                anim.SetBool("IsJumping", true);
                rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                PState.states[PlayerState.jump] = false;
            }
        }
        
    }

    void JumpCheck()
    {
        Vector2 pos = transform.position;
        Vector2 colPos = pos + offset;

        Vector2 start = colPos - new Vector2(size.x / 2, size.y / 2);
        Vector2 fin = colPos - new Vector2(-size.x / 2, (size.y / 2) + 0.1f);
        PState.states[PlayerState.jump] = Physics2D.OverlapArea(start, fin, LayerMask.GetMask("Platform"));
        if (PState.states[PlayerState.jump])
        {
            anim.SetBool("IsJumping", false);
        }
    }
}

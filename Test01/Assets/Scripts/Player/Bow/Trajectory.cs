using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    float x = 0f;
    float y = -2f;
    Vector3 playerpos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = PlayerLocation.Instance.PlayerPosition();
        y = PlayerLocation.Instance.BowAngle() * 2;
        x = Mathf.Sqrt(1 - Mathf.Pow(PlayerLocation.Instance.BowAngle(), 2)) * PlayerLocation.Instance.hodir() * 2;
        playerpos.x = playerpos.x + x;
        playerpos.y = playerpos.y + y;
        transform.position = playerpos;
        transform.localScale = new Vector3(PlayerLocation.Instance.hodir(), 1f, 1f);
        transform.right = new Vector2(x, y);

    }
}

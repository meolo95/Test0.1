using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] Transform back2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (PlayerLocation.Instance.PlayerPosition().x  > transform.position.x)
        {
            var nextPos = transform.position;
            nextPos.x += 55f;
            back2.transform.position = nextPos;
        }
        if (PlayerLocation.Instance.PlayerPosition().x < transform.position.x)
        {
            var nextPos = transform.position;
            nextPos.x -= 55f;
            back2.transform.position = nextPos;
        }
    }
}

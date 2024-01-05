using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerManager Instance = null;
    [SerializeField] public GameObject player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayerSpawn(GameObject playerSpawn)
    {
        player.transform.position = playerSpawn.transform.position;
    }
}

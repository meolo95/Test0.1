using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject ending;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLocation.Instance.isEnding)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                KeyManager.Instance.optionManager.QuitGame();
                
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerLocation.Instance.isPlay = false;
            PlayerLocation.Instance.isEnding = true;
            ending.SetActive(true);
            ending.GetComponent<Credit>().SetCredit();
        }
    }
}

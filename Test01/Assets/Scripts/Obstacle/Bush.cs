using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class Bush : MonoBehaviour
{
    public Light2D back;
    SpriteRenderer spRen;

    [SerializeField] GameObject BGM;

    // Start is called before the first frame update
    void Start()
    {
        spRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            back.intensity = 0f;
            spRen.color = new Color(1f, 1f, 1f, 0.5f);
            BGM.GetComponent<AudioSource>().volume = 0.33f;
            SoundManager.Instance.Play("Bush");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            back.intensity = 1f;
            spRen.color = new Color(1f, 1f, 1f, 1f);
            BGM.GetComponent<AudioSource>().volume = 1f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PUIControl : MonoBehaviour
{
    public static PUIControl Instance = null;

    [SerializeField] TextMeshProUGUI arrows;
    [SerializeField] GameObject[] stars;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        arrows.SetText(PlayerManage.Instance.arrow.ToString());
    }

    public void SetStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
        }
        for (int i = 0; i < KeyManager.Instance.level; i++)
        {
            stars[i].SetActive(true);
        }
    }
}

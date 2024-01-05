using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clear;
    [SerializeField] TextMeshProUGUI kills;
    [SerializeField] TextMeshProUGUI hits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCredit()
    {
        int s = Mathf.FloorToInt(PlayerLocation.Instance.timer);
        kills.SetText(PlayerLocation.Instance.kills.ToString());
        hits.SetText(PlayerLocation.Instance.hits.ToString());
        string m = PlayerLocation.Instance.min.ToString() + ":" + s;
        clear.SetText(m);
    }
}

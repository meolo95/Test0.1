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
        int s = Mathf.FloorToInt(PlayerManage.Instance.timer);
        kills.SetText(PlayerManage.Instance.kills.ToString());
        hits.SetText(PlayerManage.Instance.hits.ToString());
        string m = PlayerManage.Instance.min.ToString() + ":" + s;
        clear.SetText(m);
    }
}

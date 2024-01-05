using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartManager : MonoBehaviour
{
    [SerializeField] bool isblue;

    [SerializeField] public GameObject heart;
    public List<Image> hearts;

    float heartFill;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 24 * 0.5f; i++)
        {
            GameObject h = Instantiate(heart, this.transform);

            hearts.Add(h.GetComponent<Image>());
        }

        if (!isblue)
        {
            heartFill = PlayerLocation.Instance.PlayerHp();
        }
        else
        {
            heartFill = 0f;
        }

        foreach (Image i in hearts)
        {
            i.fillAmount = heartFill * 0.5f;
            heartFill -= 2f;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHearts()
    {
        float heartFill = PlayerLocation.Instance.PlayerHp();

        foreach(Image i in hearts)
        {
            i.fillAmount = heartFill * 0.5f;
            heartFill -= 2f;
        }
    }

    public void FrozenHearts()
    {
        float heartFrozen = PlayerLocation.Instance.FrozenHp();
        foreach(Image i in hearts)
        {
            i.fillAmount = heartFrozen * 0.5f;
            heartFrozen -= 2f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartClass : MonoBehaviour
{
    [SerializeField] public GameObject heart;
    public List<Image> hearts;
    protected float heartFill;

    protected virtual void Awake()
    {
        for (int i = 0; i < 24 * 0.5f; i++)
        {
            GameObject h = Instantiate(heart, this.transform);

            hearts.Add(h.GetComponent<Image>());
        }
        UpdateHearts();
    }

    public virtual void UpdateHearts()
    {

    }
}
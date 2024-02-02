using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] public int demage;
    public bool isUsed = false;

    public GameObject usedArrow;
    public GameObject blockedArrow;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable()
    {
        isUsed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

}

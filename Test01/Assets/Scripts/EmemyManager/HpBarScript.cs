using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarScript : MonoBehaviour
{

    [SerializeField] GameObject hpBar = null;

    List<Transform> objList = new List<Transform>();
    List<GameObject> hpBarList = new List<GameObject>();

    Camera cam = null;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

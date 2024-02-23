using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraContol : MonoBehaviour
{
    public static CameraContol Instance = null;

    public Transform target;
    [SerializeField]  [Range(0.0f, 10f)] float cameraSpeed;
    float y = 0f;

    bool isStart;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            //Destroy(Instance);
            //Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        
        //target = PlayerManager.Instance.player.transform;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetMain()
    {
        transform.position = new Vector3(0f, 0f, -1f);
    }

    void LateUpdate()
    {
        if (PlayerManage.Instance.isPlay == true)
        {

            var pos = new Vector3(target.position.x, target.position.y, -10f);

            transform.position = Vector3.Lerp(transform.position, pos, cameraSpeed * Time.deltaTime);
        }


        


    }
}

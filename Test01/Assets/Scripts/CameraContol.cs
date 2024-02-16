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

    public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
    }

    void LateUpdate()
    {
        if (PlayerManage.Instance.isPlay == true)
        {

            var pos = new Vector3(target.position.x, target.position.y, -10f);

            transform.position = Vector3.Lerp(transform.position, pos, cameraSpeed * Time.deltaTime);
        }


        // target에 character 넣고 pos에 target position 넣음. 이후 transform.position(카메라 위치) = 카메라 위치 + (플레이어 위치 - 카메라 위치) * 카메라 속도,
        // 이게 되는 이유는 매 프레임마다 플레이어 위치와 카메라 위치가 가까워지며 최종적으로 0에 수렴하기 때문에 
        //카메라 속도가 1이든 0.1이든 카메라 위치가 플레이어 위치를 넘을 수 없음

        


    }
}

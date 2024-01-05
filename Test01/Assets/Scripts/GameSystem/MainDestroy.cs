using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainDestroy : MonoBehaviour
{
    private void Start()
    {
        // 씬 전환 이벤트 리스너 등록
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDestroy()
    {
        // 씬 전환 이벤트 리스너 해제
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        // 씬이 언로드될 때 호출됨
        if (scene.name == "MainMenu")
        {
            // 메인 메뉴 씬으로 전환할 때 이 오브젝트를 파괴
            Destroy(gameObject);
        }
    }
}

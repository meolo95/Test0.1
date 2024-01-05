using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainDestroy : MonoBehaviour
{
    private void Start()
    {
        // �� ��ȯ �̺�Ʈ ������ ���
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDestroy()
    {
        // �� ��ȯ �̺�Ʈ ������ ����
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        // ���� ��ε�� �� ȣ���
        if (scene.name == "MainMenu")
        {
            // ���� �޴� ������ ��ȯ�� �� �� ������Ʈ�� �ı�
            Destroy(gameObject);
        }
    }
}

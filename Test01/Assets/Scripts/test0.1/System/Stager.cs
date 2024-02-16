using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Stager : MonoBehaviour
{
    public static Stager Instance = null;
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

        SceneManager.sceneLoaded += OnStart;
    }

    public bool isPlay;
    [SerializeField] GameObject player;

    void OnStart(Scene scene, LoadSceneMode mode)
    {
        player.transform.position = new Vector3(-14.7f, -6.7f, 0f);
        Debug.Log("SceneLoaded");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public int stageNumber = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != null && Instance != this)
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        testStage();
    }

    public void NextStage()
    {
        

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            stageNumber++;
            SceneManager.LoadScene(nextScene);
        }


    }



    void testStage()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;

            if (nextScene < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextScene);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            string nextScene = "Stage1-2";
            SceneManager.LoadScene(nextScene);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            string nextScene = "Stage2-1";
            SceneManager.LoadScene(nextScene);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            string nextScene = "Stage2-2";
            SceneManager.LoadScene(nextScene);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            string nextScene = "Stage3-1";
            SceneManager.LoadScene(nextScene);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            string nextScene = "Stage3-2";
            SceneManager.LoadScene(nextScene);
        }
    }
}

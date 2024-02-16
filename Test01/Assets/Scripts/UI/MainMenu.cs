using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelWindow;
    // Start is called before the first frame update

    void Awake()
    {
        KeyManager.Instance.SetMain(true);
        KeyManager.Instance.level = 0;
        //KeyManager.Instance.optionManager.QuitSetting();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickNewGame()
    {
        levelWindow.SetActive(true);
    }
    public void OnClickLoad()
    {

    }
    public void OnClickSettings()
    {
        KeyManager.Instance.optionManager.OnClickSettings();
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickLevel(int num)
    {
        KeyManager.Instance.level = num;
        levelWindow.SetActive(false);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        string nextScene = "Stage1";
        PlayerManage.Instance.isPlay = true;
        Stager.Instance.isPlay = true;
        Time.timeScale = 1;
        KeyManager.Instance.SetMain(false);
        SceneManager.LoadScene(nextScene);
        
        PlayerManage.Instance.UIActive();
        PUIControl.Instance.SetStars();
        PlayerManage.Instance.AllNewRefresh(num);
    }
}

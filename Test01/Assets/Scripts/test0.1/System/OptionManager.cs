using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] GameObject optionPanel;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject overPanel;

    [SerializeField] Button shoot;
    [SerializeField] Button attack1;
    [SerializeField] Button attack2;
    public bool isMain = false;
    public bool isOver;

    public bool isKeyboard;
    public bool isMouse;
    public bool isConsole;

    [SerializeField] AudioClip clip;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)  && isMain == false)
        {
            if (isOver == false && PlayerManage.Instance.isPlay == true)
            {
                TogglePause();
            }
            
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            optionPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            optionPanel.SetActive(false);
            settingPanel.SetActive(false);
        }
    }

    public void OnClickSettings()
    {
        settingPanel.SetActive(true);
    }

    public void OnClickMouse()
    {
        KeyManager.Instance.isMouse = true;
        KeyManager.Instance.isKey = false;
        shoot.interactable = false;
        attack1.interactable = false;
        attack2.interactable = false;
    }
    public void OnClickKey()
    {
        KeyManager.Instance.isMouse = false;
        KeyManager.Instance.isKey = true;
        shoot.interactable = true;
        attack1.interactable = true;
        attack2.interactable = true;
    }

    public void SetOverPanel()
    {
        isOver = true;
        overPanel.SetActive(true);
    }

    public void OnClickRestart()
    {
        ObjectPoolManager.Instance.ReleaseAll();
        isOver = false;
        //PlayerManage.Instance.isPlay = true;
        isMain = false;
        overPanel.SetActive(false);
        //PlayerLocation.Instance.p.SetActive(true);
        //PlayerLocation.Instance.SetPlayerNormal();
        PlayerManage.Instance.PlayerReset();

        SceneManager.LoadScene("Stage1");
    }
    public void BackToOption()
    {
        settingPanel.SetActive(false);
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        optionPanel.SetActive(false);
    }

    public void QuitGame()
    {
        ObjectPoolManager.Instance.ReleaseAll();
        Time.timeScale = 1;
        isOver = false;
        isMain = true;
        //PlayerLocation.Instance.isEnding = false;
        //PlayerLocation.Instance.timer = 0f;
        optionPanel.SetActive(false);
        settingPanel.SetActive(false);
        overPanel.SetActive(false);
        PlayerManage.Instance.UIDActive();
        string nextScene = "MainMenu";
        //PlayerLocation.Instance.SetPlayerNormal();
        //PlayerLocation.Instance.SetNormal();
        //PlayerLocation.Instance.p.SetActive(false);
        //PlayerLocation.Instance.pManager.SetActive(false);
        //PlayerLocation.Instance.SetMain();
        PlayerManage.Instance.PlayerReset();
        PlayerManage.Instance.isPlay = false;
        PlayerManage.Instance.isEnding = false;
        SceneManager.LoadScene(nextScene);
    }

    public void QuitSetting()
    {
        isOver = false;
        isMain = true;
        //PlayerLocation.Instance.SetPlayerNormal();
        //PlayerLocation.Instance.p.SetActive(false);
        //PlayerLocation.Instance.pManager.SetActive(false);
    }

    public void QuitOverGame()
    {
        ObjectPoolManager.Instance.ReleaseAll();
        isOver = false;
        isMain = true;
        optionPanel.SetActive(false);
        settingPanel.SetActive(false);
        overPanel.SetActive(false);
        PlayerManage.Instance.PlayerReset();
        PlayerManage.Instance.UIDActive();
        string nextScene = "MainMenu";
        //PlayerLocation.Instance.p.SetActive(true);
        //PlayerLocation.Instance.SetPlayerNormal();
        //PlayerLocation.Instance.p.SetActive(false);
        //PlayerLocation.Instance.pManager.SetActive(false);
        PlayerManage.Instance.isPlay = false;
        SceneManager.LoadScene(nextScene);

    }
}

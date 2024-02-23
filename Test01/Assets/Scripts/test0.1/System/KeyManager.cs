using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum KeyAction { Shoot, Attack1, Attack2, Jump, Left, Right, Down, Roll, Up, Hook }

public static class KeySetting { public static Dictionary<KeyAction, KeyCode>keys = new Dictionary<KeyAction, KeyCode>();}
public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance = null;
    public OptionManager optionManager;
    public bool isMouse = false;
    public bool isKey = true;

    public int level = 5;

    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.R, KeyCode.E, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.Z, KeyCode.UpArrow, KeyCode.A};
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        for (int i = 0; i <(int)KeyAction.Hook + 1; i++)
        {
            if (!KeySetting.keys.ContainsKey((KeyAction)i))
            {
                KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
            }
        }
        
        optionManager = GetComponent<OptionManager>();
        

    }

    public void SetMain(bool state)
    {
        optionManager.isMain = state;
    }
    public bool GetPause()
    {
        return optionManager.isPaused;
    }



    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey)
        {
            KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            key = -1;
        }
    }
    int key = -1;
    public void ChangeKey(int num)
    {
        key = num;
    }

}
